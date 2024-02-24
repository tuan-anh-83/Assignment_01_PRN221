using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BookServices;

namespace SE160143_Ass1
{
    /// <summary>
    /// Interaction logic for ListBooksForMem.xaml
    /// </summary>
    public partial class ListBooksForMem : Window
    {

        private IBookService bookService = null;
        public ListBooksForMem()
        {
            InitializeComponent();

            InitializeComponent();
            bookService = new BookService();
           // accountService = new AccountService();
            /*dgBook.ItemsSource = bookService.GetBooks().Select(c => new{c.BookId, c.BookName, c.Description, c.ReleaseDate, c.Quantity, c.Price, c.Author, c.BookCategoryId}).ToList();*/
            dgBook.ItemsSource = bookService.GetBooks();

        }
    }
}
