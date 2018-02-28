using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using tinoModaFuka.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

//This enables me test if I can transfer/manipulate a list from Server Side.

namespace tinoModaFuka
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class testList : Page
    {
        private List<Person> Letter { get; set; }

        public testList()
        {
            this.InitializeComponent();
            Letter = new List<Person>();
            Letter = TesterManger.changeList();
        }
    }

    public class TesterManger
    {

        public static List<Person> changeList()
        {
            var lister = new List<Person>();

            for (int i = 0; i < 10; i++)
            {
                lister.Add(new Person
                {
                    GuestName = "Yung " + i.ToString(),
                    GuestAge = "24 " + i.ToString()
                });
            }

            return lister;
        }

    }
}
