using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
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
    public sealed partial class exampleHeader : Page
    {
        public exampleHeader()
        {
            this.InitializeComponent();
        }

        #region Methods 
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
                ctlGrid.Children.Clear();
                load_Table_Header();

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
                    //----< Einzel-File anfuegen >---- 
                    iRow++;

                    //< add Row > 
                    RowDefinition row = new RowDefinition();
                    row.Height = new GridLength(20);
                    ctlGrid.RowDefinitions.Add(row);
                    //</ add Row > 

                    //< Row Background > 
                    Border row_Background = new Border();
                    row_Background.BorderThickness = new Thickness(1);
                    if (iRow % 2 == 0)
                    {
                        row_Background.Background = new SolidColorBrush(Color.FromArgb(10, 0, 0, 0));
                    }
                    Grid.SetRow(row_Background, iRow);
                    Grid.SetColumnSpan(row_Background, 3);
                    ctlGrid.Children.Add(row_Background);
                    //</ Row Background > 

                    try
                    {
                        //----< Try Insert Item >---- 
                        ctlGrid.RowDefinitions.Add(new RowDefinition());
                        //--< Filename >-- 
                        string sFilename = file.DisplayName;
                        TextBlock lblName = new TextBlock();
                        lblName.Text = sFilename;
                        lblName.IsTextSelectionEnabled = true;
                        Grid.SetRow(lblName, iRow);
                        Grid.SetColumn(lblName, 0);
                        ctlGrid.Children.Add(lblName);
                        //--</ Filename >-- 

                        //FileInfo fInfo = new FileInfo(sFilename); 

                        //--< Date >-- 
                        TextBlock sDate = new TextBlock();
                        sDate.Text = file.DateCreated.ToString("yyyy-MM-dd hh:mm:ss");
                        sDate.IsTextSelectionEnabled = true;
                        Grid.SetRow(sDate, iRow);
                        Grid.SetColumn(sDate, 1);
                        ctlGrid.Children.Add(sDate);
                        //--</ Date >-- 

                        //--< Size >-- 
                        Windows.Storage.FileProperties.BasicProperties fileProperties = await file.GetBasicPropertiesAsync();
                        ulong size = fileProperties.Size;
                        size = size / 1000;
                        string sFileSize = string.Format("{0:n0} MB", size);

                        TextBlock lblSize = new TextBlock();
                        lblSize.Text = sFileSize;
                        lblSize.IsTextSelectionEnabled = true;
                        lblSize.HorizontalAlignment = HorizontalAlignment.Right;
                        lblSize.Margin = new Thickness(0, 0, 20, 0);
                        Grid.SetRow(lblSize, iRow);
                        Grid.SetColumn(lblSize, 2);
                        ctlGrid.Children.Add(lblSize);
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
                //------</ @Loop: Files >------ 
                //----</ Files holen >---- 
                ctlGrid.UpdateLayout();

                //-------</ load_Grid() >-------- 
            }
        }
            #endregion /Methods

        private void btnFolder_Click(object sender, RoutedEventArgs e)
        {
            load_Grid();
        }

        private void load_Table_Header()
        {
            //< add Row > 
            RowDefinition row = new RowDefinition();
            row.Height = new GridLength(20);
            ctlGrid.RowDefinitions.Add(row);
            //</ add Row > 

            //< Row Background > 
            Border row_Background = new Border();
            row_Background.BorderThickness = new Thickness(1);
            row_Background.Background = new SolidColorBrush(Color.FromArgb(255, 225, 65, 169));
            Grid.SetRow(row_Background, 0);
            Grid.SetColumnSpan(row_Background, 3);
            ctlGrid.Children.Add(row_Background);
            //</ Row Background > 

            try
            {
                //----< Try Insert Item >---- 
                ctlGrid.RowDefinitions.Add(new RowDefinition());
                //--< Filename >-- 
                TextBlock lblName = new TextBlock();
                lblName.Text = "Filename";
                lblName.IsTextSelectionEnabled = true;
                Grid.SetRow(lblName, 0);
                Grid.SetColumn(lblName, 0);
                ctlGrid.Children.Add(lblName);
                //--</ Filename >-- 

                //FileInfo fInfo = new FileInfo(sFilename); 

                //--< Date >-- 
                TextBlock sDate = new TextBlock();
                sDate.Text = "Date";
                sDate.IsTextSelectionEnabled = true;
                Grid.SetRow(sDate, 0);
                Grid.SetColumn(sDate, 1);
                ctlGrid.Children.Add(sDate);
                //--</ Date >-- 

                //--< Size >-- 

                TextBlock lblSize = new TextBlock();
                lblSize.Text = "FileSize MB";
                lblSize.IsTextSelectionEnabled = true;
                lblSize.HorizontalAlignment = HorizontalAlignment.Right;
                lblSize.Margin = new Thickness(0, 0, 20, 0);
                Grid.SetRow(lblSize, 0);
                Grid.SetColumn(lblSize, 2);
                ctlGrid.Children.Add(lblSize);
                //--</ Size >-- 
            }
            catch (Exception ex)
            {
                //----< Error Insert Item >---- 
                MessageDialog msg = new MessageDialog(ex.Message);
                //throw; 
                //----</ Error Insert Item >---- 
            }
            ctlGrid.UpdateLayout();


        }

        private void btnTest_Click(object sender, RoutedEventArgs e)

        {

            String sHTML = "";
            int iRow = 0;
            string sRow = "<TR>";

            //*Select Highlight 
            foreach (var item in ctlGrid.Children)
            {

                if (item.GetType() == typeof(TextBlock))
                {
                    TextBlock lbl = item as TextBlock;
                    int cRow = Grid.GetRow(lbl);
                    int cColumn = Grid.GetColumn(lbl);
                    if (cRow != iRow)
                    {
                        //< new row > 
                        sRow = sRow + "</TR>";
                        sHTML = sHTML + sRow;
                        sRow = "";
                        iRow = Grid.GetRow(lbl) + 0;
                        //</ new row > 
                    }

                    if (cColumn == 2)
                    { sRow += "<TD style='text-align:right';>"; }
                    else
                    { sRow += "<TD>"; }
                    sRow += lbl.Text + "</TD>";
                }

            }
            sHTML = sHTML + sRow + "</TR>";
            sHTML = "<TABLE>" + sHTML + "</TABLE>";

            string sExport = HtmlFormatHelper.CreateHtmlFormat(sHTML);
            DataPackage dataPackage = new DataPackage();
            dataPackage.SetHtmlFormat(sExport);
            Clipboard.SetContent(dataPackage);

            #region MyRegion
            //*Select Highlight 

            //foreach (var item in ctlGrid.Children ) 
            //{ 

            // if(item.GetType()==typeof(TextBlock )) 
            // { 
            // TextBlock tbx = item as TextBlock; 
            // tbx.FontWeight = FontWeights.Bold; 
            // } 

            // if (item.GetType() == typeof(Border)) 
            // { 
            // Border border = item as Border; 
            // border.Background = new SolidColorBrush(Color.FromArgb(10, 0, 0, 255)); 
            // } 
            //} 


            //*Clipboard 

            ////< open File-Explorer > 
            //var dataPackage = new DataPackage(); 
            //dataPackage.SetData(..) 

            //// Request a copy operation from targets that support different file operations, like File Explorer 
            //dataPackage.RequestedOperation = DataPackageOperation.Copy; 
            //Clipboard.SetContent(dataPackage);  
            #endregion
   
        }

    }
}
