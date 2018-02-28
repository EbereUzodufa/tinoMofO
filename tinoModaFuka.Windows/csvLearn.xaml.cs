using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
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
    public sealed partial class csvLearn : Page
    {
        public csvLearn()
        {
            this.InitializeComponent();
        }

        private async void  getFileName()
        {
            var fileOpen = new FileOpenPicker();
            fileOpen.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            fileOpen.ViewMode = PickerViewMode.List;

            //No filter give error
            //fileOpen.FileTypeFilter.Add("*");
            //fileOpen.FileTypeFilter.Add(".jpeg");
            //fileOpen.FileTypeFilter.Add(".png");
            //fileOpen.FileTypeFilter.Add(".jpg");
            //fileOpen.FileTypeFilter.Add(".bmp"); .xlsx, xlsm, .xltx, .xltm, .xls, .xlt

            fileOpen.FileTypeFilter.Add(".xlsx");
            fileOpen.FileTypeFilter.Add(".xlsm");
            fileOpen.FileTypeFilter.Add(".xltx");
            fileOpen.FileTypeFilter.Add(".xltm");
            fileOpen.FileTypeFilter.Add(".xls");
            fileOpen.FileTypeFilter.Add(".xlt");
            fileOpen.FileTypeFilter.Add(".csv");

            StorageFile file = await fileOpen.PickSingleFileAsync();

            string fileName, fileDisplayName;

            if (file != null)
            {
                fileName = file.DisplayName; //removes extension name
                //fileDisplayName = file.ContentType;
                txtTitle.Text = "File Name: " + file.DisplayName + "\r\n" 
                    + "File Content Type: " + file.ContentType + "\r\n"  //eg image/jpeg
                    + "FileType: "  + file.FileType.ToString() + "\r\n"  //eg .jpg
                    + "Display Type: " + file.DisplayType.ToString();    //eg JPG File
            }

            else
            {
                txtTitle.Text = "File Name: " + "\r\n" + "File Display Name: ";
            }

        }

        private async void btnGetFile_Click(object sender, RoutedEventArgs e)
        {
            getFileName();
        }

        private void addRowGrid()
        {

        }
    }
}
