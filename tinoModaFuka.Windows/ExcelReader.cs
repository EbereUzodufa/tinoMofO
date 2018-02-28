using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Storage;

namespace tinoModaFuka
{
    public class ExcelReader
    {
        public static StorageFile TargetFile { get; set; }

        static List<string> _sharedStrings;

        static List<Dictionary<string, string>> _derivedData;

        public static List<Dictionary<string, string>> DerivedData
        {
            get
            {
                return _derivedData;
            }
        }
        static List<string> _header;

        public static List<string> Headers { get { return _header; } }

        public static void StartReadFile()
        {
            ZipArchive z = new ZipArchive(TargetFile.OpenStreamForReadAsync().Result);
            var worksheet = z.GetEntry("xl/worksheets/sheet1.xml");
            var sharedString = z.GetEntry("xl/sharedStrings.xml");

            //get shared string
            _sharedStrings = new List<string>();
            using (var sr = sharedString.Open())
            {
                XDocument xdoc = XDocument.Load(sr);
                _sharedStrings =
                    (
                    from e in xdoc.Root.Elements()
                    select e.Elements().First().Value
                    ).ToList();
            }

            //get header
            using (var sr = worksheet.Open())
            {
                XDocument xdoc = XDocument.Load(sr);
                //get element to first sheet data
                XNamespace xmlns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
                XElement sheetData = xdoc.Root.Element(xmlns + "sheetData");

                _header = new List<string>();
                //build header first
                var firstRow = sheetData.Elements().First();
                //full of c
                foreach (var c in firstRow.Elements())
                {
                    //the c element, if have attribute t, will need to consult sharedStrings
                    string val = c.Elements().First().Value;
                    if (c.Attribute("t") != null)
                    {
                        _header.Add(_sharedStrings[Convert.ToInt32(val)]);
                    }
                    else
                    {
                        _header.Add(val);
                    }

                }
                //build content now
                _derivedData = new List<Dictionary<string, string>>();

                foreach (var row in sheetData.Elements())
                {
                    //skip row 1
                    if (row.Attribute("r").Value == "1")
                        continue;
                    Dictionary<string, string> rowData = new Dictionary<string, string>();
                    int i = 0;
                    foreach (var c in row.Elements())
                    {
                        //down to each c element
                        string val = c.Elements().First().Value;
                        if (c.Attribute("t") != null)
                        {
                            rowData.Add(_header[i], _sharedStrings[Convert.ToInt32(val)]);
                        }
                        else
                        {
                            rowData.Add(_header[i], val);
                        }
                        i++;
                    }
                    _derivedData.Add(rowData);
                }
            }

            string s = ";";
        }

    }
}
