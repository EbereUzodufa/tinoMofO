using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tinoModaFuka.Models;

namespace tinoModaFuka.ViewModels
{
    public class MainViewModel
    {
        public List<Person> PersonList { get; set; }

        public class TestList
        {
            public string name { get; set; }
            public string age { get; set; }
            public string division { get; set; }
        }
        
        public List<TestList> TesterLists { get; set; }

        public MainViewModel()
        {

            #region Note
            //Difficult is increased in each step
            #endregion
            #region Test 1
            //PersonList = new List<Person>
            //{
            //    new Person
            //    {
            //        Name="James",
            //        Age=24
            //    },
            //    new Person
            //    {
            //        Name="LeBron",
            //        Age=33
            //    },
            //    new Person
            //    {
            //        Name="King",
            //        Age=54
            //    }
            //}; 
            #endregion

            #region Second Test
            //PersonList = new List<Person>();

            //for (int i = 0; i < 10; i++)
            //{
            //    PersonList.Add(new Person
            //    {
            //        Name="Person " + i.ToString(),
            //        Age=i
            //    });
            //} 
            #endregion

            #region Test 3

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

            
            PersonList = new List<Person>();

            foreach (var item in TesterLists)
            {
                PersonList.Add(new Person
                {
                    GuestName = "Jamii " + item.name,
                    GuestAge = item.age,
                    GuestDivision = item.division
                });
            }

            PersonList.Add(new Person
            {
                GuestName="JAmii test",
                //Age="",
                GuestDivision="Tester"
            });

            PersonList.Add(new Person
            {
                GuestName = "JAmii Test 2",
                GuestAge = "",
                GuestDivision = "Tester 2"
            });
            #endregion
        }

    }
}
