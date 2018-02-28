using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using tinoModaFuka.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
//using static tinoModaFuka.Models.Book;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace tinoModaFuka
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnVisitor_Click(object sender, RoutedEventArgs e)
        {
            JamesBoy.Visibility = Visibility.Collapsed;
            JudeMan.Visibility = Visibility.Visible;
            txtTitle.Text = "List of Visitors";
            btnVisitor.Background = new SolidColorBrush(Color.FromArgb(255, 225, 65, 169));
            btnGuest.Background = new SolidColorBrush(Color.FromArgb(1, 0, 0, 0));
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            JamesBoy.Visibility = Visibility.Visible;
            JudeMan.Visibility = Visibility.Collapsed;
            txtTitle.Text = "List of Guests";
            btnGuest.Background = new SolidColorBrush(Color.FromArgb(255, 225, 65, 169));
            btnVisitor.Background = new SolidColorBrush(Color.FromArgb(1, 0, 0, 0));
        }

        private void Page_LayoutUpdated(object sender, object e)
        {
            JamesBoy.Visibility = Visibility.Collapsed;
            JudeMan.Visibility = Visibility.Visible;
            txtTitle.Text = "List of Visitors";
        }

        private void btnCSV_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(csvLearn));
        }

        private void btnExampleHeader_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(exampleHeader));
        }

        private void btnExampleListView_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(exampleListView));
        }

        private void btnReader_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ExampleReader));
        }

        //private void Grid_Loaded(object sender, RoutedEventArgs e)
        //{
        //    JamesBoy.Visibility = Visibility.Collapsed;
        //    JudeMan.Visibility = Visibility.Visible;
        //    txtTitle.Text = "List of Visitors";
        //}
    }

    public class jeez
    {
        public List<Person> PersonList { get; set; }
        public List<Person> PersonList2 { get; set; }

        public class TestList
        {
            public string name { get; set; }
            public string division { get; set; }
            public string age { get; set; }
        }

        public class TestList2
        {
            public string name { get; set; }
            public string division { get; set; }
            public string age { get; set; }
        }

        public List<TestList> TesterLists { get; set; }
        public List<TestList2> TesterLists2 { get; set; }

        public jeez()
        {
            TesterLists = new List<TestList>();

            for (int i = 0; i < 3; i++)
            {
                TesterLists.Add(new TestList
                {
                    name = "Uii " + i.ToString(),
                    age = i.ToString(),
                    division = "Div " + i.ToString()
                });
            }

            TesterLists2 = new List<TestList2>();

            for (int i = 0; i < 3; i++)
            {
                TesterLists2.Add(new TestList2
                {
                    name = "Uii " + i.ToString(),
                    age = i.ToString(),
                    division = "Div " + i.ToString()
                });
            }

            PersonList = new List<Person>();

            PersonList2 = new List<Person>();

            jeezGuest();

            jeezVisitor();

        }
        public void jeezGuest()
        {
         

            PersonList = new List<Person>();

            #region Guest
            foreach (var item in TesterLists)
            {
                PersonList.Add(new Person
                {
                    GuestName = "Guest " + item.name,
                    GuestAge = item.age,
                    GuestDivision = item.division
                });
            }

            PersonList.Add(new Person
            {
                GuestName = "Guest test",
                //Age="",
                GuestDivision = "Tester"
            });

            PersonList.Add(new Person
            {
                GuestName = "Guest Test 2",
                GuestAge = "",
                GuestDivision = "Tester 2"
            });

            #endregion
        }

        public void jeezVisitor()
        {
   
            PersonList2 = new List<Person>();

            #region Visitor


            foreach (var item in TesterLists2)
            {
                PersonList2.Add(new Person
                {
                    VisitorName = "Visitor " + item.name,
                    VisitorAge = item.age,
                    VisitorDivision = item.division
                });
            }

            PersonList2.Add(new Person
            {
                VisitorName = "Visitor test",
                //Age="",
                VisitorDivision = "Tester"
            });

            PersonList2.Add(new Person
            {
                VisitorName = "Visitor Test 2",
                VisitorAge = "",
                VisitorDivision = "Tester 2"
            });

            #endregion

        }

    }
}
