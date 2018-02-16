//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using tinoModaFuka.ViewModels;

//namespace tinoModaFuka.Models
//{
//    public class Book
//    {
//        public int BookId { get; set; }
//        public string Title { get; set; }
//        public string Author { get; set; }
//        public string CoverImage { get; set; }

//        public ParameterCommand parameterCommand { get; set; }

//        public class BookManager  //Put this outside the class and you aint going shit
//        {
//            public static List<Book> GetBooks()
//            {
//                var books = new List<Book>();
//                books.Add(new Book { BookId = 1, Title = "Madness", Author = "Kip", CoverImage = "" });
//                books.Add(new Book { BookId = 1, Title = "Madness", Author = "Kip", CoverImage = "" });
//                books.Add(new Book { BookId = 1, Title = "Madness", Author = "Kip", CoverImage = "" });
//                books.Add(new Book { BookId = 1, Title = "Madness", Author = "Kip", CoverImage = "" });

//                return books;
//            }    
//        }

//        public void ParameterMethod(Book book)
//        {
//            Add(book);
//        }
//    }
//}
