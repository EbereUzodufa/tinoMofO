//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;
//using tinoModaFuka.Models;

//namespace tinoModaFuka.ViewModels
//{
//    public class ParameterCommand 
//    {
//        public Book Book { get; set; }

//        public ParameterCommand(Book book)
//        {
//            this.Book = book;
//        }
//        public event EventHandler CanExecuteChanged;

//        public bool CanExecute(object parameter)
//        {
//            throw new NotImplementedException();
//        }

//        public void Execute(object parameter)
//        {
//            this.Book.ParameterMethod(parameter as Book);
//        }
//    }
//}
