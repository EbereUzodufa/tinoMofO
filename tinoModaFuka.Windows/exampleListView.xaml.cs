using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace tinoModaFuka
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class exampleListView : Windows.UI.Xaml.Controls.Page
    {
        private int listIndex;
        public exampleListView()
        {
            this.InitializeComponent();
        }

        public void btnFolder_Click(object sender, RoutedEventArgs e)
        {
            load_Grid();
        }

        private async void load_Grid()
        {
            //-------< load_Grid() >-------- 
            FolderPicker picker = new FolderPicker();
            picker.FileTypeFilter.Add("*");
            picker.ViewMode = PickerViewMode.List;
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            StorageFolder objFolder = await picker.PickSingleFolderAsync();

            //< Bilder laden > 
            if (objFolder != null)
            {
                lstviewDate.Items.Clear();
                lstviewFileName.Items.Clear();
                lstviewFileSize.Items.Clear();

                string sPath = objFolder.Path;

                //< Zugriff global speichern > 
                StorageApplicationPermissions.FutureAccessList.Add(objFolder, "metadata");
                //< Zugriff global speichern > 

                //clsSettings.fp_Container_Setting_Set("Folders", sPath, sPath);
                tbxFolder.Text = sPath;

                //----< Files holen >---- 
                IReadOnlyList<StorageFile> fileList = await objFolder.GetFilesAsync();


                //------< @Loop: Files >------ 
                int iRow = 0;
                foreach (StorageFile file in fileList)
                {
                    try
                    {
                        string sFilename = file.DisplayName;
                        lstviewFileName.Items.Add(sFilename);
                        //--</ Filename >-- 

                        //--< Date >-- 
                        string sDate = file.DateCreated.ToString("yyyy-MM-dd hh:mm:ss");
                        lstviewDate.Items.Add(sDate);
                        //--</ Date >-- 

                        //--< Size >-- 
                        Windows.Storage.FileProperties.BasicProperties fileProperties = await file.GetBasicPropertiesAsync();
                        ulong size = fileProperties.Size;
                        size = size / 1000;
                        string sFileSize = string.Format("{0:n0} MB", size);
                        lstviewFileSize.Items.Add(sFileSize);
                        //--</ Size >-- 
                    }
                    catch (Exception ex)
                    {
                        //----< Error Insert Item >---- 
                        MessageDialog msg = new MessageDialog(ex.Message);
                        //throw; 
                        //----</ Error Insert Item >---- 
                    }
                }
            }
        }

        private void ItemSelected(object sender, ItemClickEventArgs e)
        {
            gridDetail.Visibility = Visibility.Visible;

            ListView lst = new ListView();
            lst = sender as ListView;
            listIndex = lst.SelectedIndex;
            lstviewFileName.SelectedItem = listIndex;
            lstviewDate.SelectedItem = listIndex;
            lstviewFileSize.SelectedItem = listIndex;

            lstviewFileName.SelectedIndex = listIndex;
            lstviewDate.SelectedIndex = listIndex;
            lstviewFileSize.SelectedIndex = listIndex;

            string FileName = lstviewFileName.Items[listIndex].ToString();
            string FileDate = lstviewDate.Items[listIndex].ToString(); 
            string FileSize = lstviewFileSize.Items[listIndex].ToString() + " MB";

            //MessageDialog msg = new MessageDialog(FileName + "\r\n" + FileDate + "\r\n" + FileSize);
            //msg.ShowAsync();

            txtFileName.Text = FileName;
            txtDate.Text = FileDate;
            txtFileSize.Text = FileSize;
        }

        private void lstviewFileName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int i = lstviewFileName.SelectedIndex;
            //lstviewDate.SelectedItem = i;
            //lstviewFileSize.SelectedIndex = i;
        }

        private void lstviewFileName_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            #region ShutDown
            //if (lstviewFileName.Items != null)
            //{
            //    int i = lstviewFileName.SelectedIndex;
            //    lstviewDate.SelectedItem = i;
            //    lstviewFileSize.SelectedIndex = i;

            //}  
            #endregion

        }

        private void lstviewFileName_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var james = e.ClickedItem.ToString();
            lstviewFileName.SelectedItem = e.ClickedItem;
            //var james = lstviewFileName.SelectedItem.ToString();
            //MessageDialog msg = new MessageDialog(james);
            //msg.ShowAsync();
            ItemSelected(sender,e);
        }

        private void lstviewFileSize_ItemClick(object sender, ItemClickEventArgs e)
        {
            lstviewFileSize.SelectedItem = e.ClickedItem;
            ItemSelected(sender, e);
        }

        private void lstviewDate_ItemClick(object sender, ItemClickEventArgs e)
        {
            lstviewDate.SelectedItem = e.ClickedItem;
            ItemSelected(sender, e);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((lstviewFileName.SelectedItem!=null) && ( txtFileName.Text.Trim() !="") && (txtDate.Text.Trim() != "") && (txtFileSize.Text.Trim() != "") )
                {
                    string newFileName = txtFileName.Text;
                    string newDate = txtDate.Text;
                    string newFileSize = txtFileSize.Text;
                    lstviewFileName.Items[listIndex] = newFileName;
                }
                
            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog(ex.Message);
                msg.ShowAsync();
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            gridDetail.Visibility = Visibility.Collapsed;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gridDetail.Visibility = Visibility.Collapsed;
        }

        //public DataTable ReadExcel(string fileName, string fileExt)
        //{
        //    string conn = string.Empty;
        //    DataTable dtexcel = new DataTable();
        //    if (fileExt.CompareTo(".xls") == 0)
        //        conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
        //    else
        //        conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
        //    using (OleDbConnection con = new OleDbConnection(conn))
        //    {
        //        try
        //        {
        //            OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con); //here we read data from sheet1  
        //            oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
        //        }
        //        catch { }
        //    }
        //    return dtexcel;
        //}

        //private void btnChooseFile_Click(object sender, EventArgs e)
        //{
        //    string filePath = string.Empty;
        //    string fileExt = string.Empty;
        //    OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
        //    if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
        //    {
        //        filePath = file.FileName; //get the path of the file  
        //        fileExt = Path.GetExtension(filePath); //get the file extension  
        //        if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
        //        {
        //            try
        //            {
        //                DataTable dtExcel = new DataTable();
        //                dtExcel = ReadExcel(filePath, fileExt); //read excel file  
        //                dataGridView1.Visible = true;
        //                dataGridView1.DataSource = dtExcel;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message.ToString());
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
        //        }
        //    }
        //}
    }
}
