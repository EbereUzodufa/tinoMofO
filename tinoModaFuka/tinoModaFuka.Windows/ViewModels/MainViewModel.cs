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
            public int age { get; set; }
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

            for (int i = 0; i < 10; i++)
            {
                TesterLists.Add(new TestList
                {
                    name = "Uii " + i.ToString(),
                    age = i
                });
            }

            PersonList = new List<Person>();

            foreach (var item in TesterLists)
            {
                PersonList.Add(new Person
                {
                    Name = "Jamii " + item.name,
                    Age = item.age
                });
            } 
            #endregion

        }

    }
}
