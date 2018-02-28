using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace tinoModaFuka
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExampleReader : Page
    {
        public ExampleReader()
        {
            this.InitializeComponent();
        }

        private async void SelectImage()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            StorageFile file = await openPicker.PickSingleFileAsync();

            if (file != null)
            {
                StackPanel stackyP = new StackPanel();
                stackyP.Orientation = Orientation.Horizontal;

                Grid griddy = new Grid();
                griddy.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                griddy.Height = 150; 


                var stream = await file.OpenAsync(FileAccessMode.Read);
                BitmapImage image = new BitmapImage();
                image.SetSource(stream);

                //stackyP.Children.Add(
                //ImagePreview.Items.Add(

                ImagePreview.Items.Add(
                    new Image()
                    {
                        Source = image,
                        Width = 150,
                        Height = 150,
                        Margin = new Thickness(10)
                    }
                );

                //ImagePreview.Children.Add(stackyP);
                //ImagePreview.Items.Add(griddy);
            }
        }

        private async void SelectMultiImage()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            //For multiple image selection
            var files = await openPicker.PickMultipleFilesAsync();

            StackPanel stackyP = new StackPanel();
            stackyP.Orientation = Orientation.Horizontal;

            foreach (var singleImage in files)
            {
                var stream = await singleImage.OpenAsync(FileAccessMode.Read);
                BitmapImage image = new BitmapImage();
                image.SetSource(stream);

                ImagePreview.Items.Add(
                    new Image()
                    {
                        Source = image,
                        Width = 150,
                        Height = 150,
                        Margin = new Thickness(10)
                    }
                );
            }
            //ImagePreview.Items.Add(stackyP);
        }

        private async void SelectTextFile()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            openPicker.FileTypeFilter.Add(".txt");
            openPicker.FileTypeFilter.Add(".pdf");
            openPicker.FileTypeFilter.Add(".docx");

            StorageFile file = await openPicker.PickSingleFileAsync();

            if (file != null)
            {
                var stream = await file.OpenAsync(FileAccessMode.Read);
                using (StreamReader reader = new StreamReader(stream.AsStream()))
                {
                    FileText.Text = reader.ReadToEnd();
                }
            }
        }

        private void btnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            SelectImage();
        }

        private void btnSelectMultiImage_Click(object sender, RoutedEventArgs e)
        {
            SelectMultiImage();
        }

        private void btnSelectTextFile_Click(object sender, RoutedEventArgs e)
        {
            SelectTextFile();
        }
        private void addChildImage()
        {
           
        }
    }
}
