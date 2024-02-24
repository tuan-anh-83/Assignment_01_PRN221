using System;
using System.Collections.Generic;
using System.Drawing;
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
using BookObject;
using BookObject.Models;
using BookServices;

namespace SE160143_Ass1
{
    /// <summary>
    /// Interaction logic for BookManagementForm.xaml
    /// </summary>
    public partial class BookManagementForm : Window
    {
        private IBookService bookService = null;

        private IAccountService accountService = null;

        private IBookCateService bookCate = null;

        
        public BookManagementForm()
        {
            InitializeComponent();
            bookService = new BookService();
            accountService = new AccountService();
            
            /*dgBook.ItemsSource = bookService.GetBooks().Select(c => new{c.BookId, c.BookName, c.Description, c.ReleaseDate, c.Quantity, c.Price, c.Author, c.BookCategoryId}).ToList();*/
            dgBook.ItemsSource = bookService.GetBooks();

            dgBook.AddHandler(DataGridCell.MouseLeftButtonDownEvent, new MouseButtonEventHandler(DataGrid_CellMouseLeftButtonDown), true);

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValidData = true;
            if (!BookUtils.isNotEmpty(txtBookID.Text.Trim()))
            {
                isValidData = false;
                txtBookID.Focus();
                txtBookID.Background = Brushes.Red; ;
                MessageBox.Show("BookID can not Empty !");
            }

            try
            {
                if (isValidData)
                {
                    Book book = new Book();
                    book.BookId = txtBookID.Text.Trim();
                    book.BookName = txtBookName.Text.Trim();
                    book.Description = txtDescription.Text.Trim();
                    book.ReleaseDate = DateTime.Parse(dtReleaseDat.Text.Trim());
                    book.Price = Double.Parse(txtPrice.Text.Trim());
                    book.Quantity = int.Parse(txtQuantity.Text.Trim());
                    book.BookCategoryId = txtBookCategoryId.Text.Trim();
                    book.Author = txtAuthor.Text.Trim();

                    bookService.AddBookProfile(book);
                    MessageBox.Show("Add Book Successfull !!");
                    dgBook.ItemsSource = bookService.GetBooks();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something is wrong !! Please check again" + ex.Message);
            }


        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void DataGrid_CellMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid == null) return;

            // Lấy ra hàng được click
            var row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;
            if (row == null) return;

            // Lấy dữ liệu từ hàng được click và hiển thị lên các điều khiển TextBox và DatePicker
            var selectedBook = (Book)row.Item;
            txtBookID.Text = selectedBook.BookId;
            txtBookName.Text = selectedBook.BookName;
            txtDescription.Text = selectedBook.Description;
            dtReleaseDat.SelectedDate = selectedBook.ReleaseDate;
            txtPrice.Text = selectedBook.Price.ToString();
            txtQuantity.Text = selectedBook.Quantity.ToString();
            txtBookCategoryId.Text = selectedBook.BookCategoryId;
            txtAuthor.Text = selectedBook.Author;

            //txtBookID.IsReadOnly = true;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book book = bookService.GetBookProfileByID(txtBookID.Text.Trim());

                if (bookService != null)
                {

                    book.BookName = txtBookName.Text.Trim();
                    book.Description = txtDescription.Text.Trim();
                    book.ReleaseDate = DateTime.Parse(dtReleaseDat.Text.Trim());
                    book.Price = Double.Parse(txtPrice.Text.Trim());
                    book.Quantity = int.Parse(txtQuantity.Text.Trim());
                    book.BookCategoryId = txtBookCategoryId.Text.Trim();
                    book.Author = txtAuthor.Text.Trim();

                    bookService.UpdateBookProfile(book);
                    MessageBox.Show("Update Book Successfull !!");
                    dgBook.ItemsSource = bookService.GetBooks();
                }
                else
                {
                    MessageBox.Show("BookID isn't existed!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something is wrong !! Please check again" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtBookID.Text.Length > 0)
                {
                    bookService.DeleteBookProfile(txtBookID.Text.Trim());
                    MessageBox.Show("Delete Book Successfull !!");
                    dgBook.ItemsSource = bookService.GetBooks();
                }
                else
                {
                    MessageBox.Show("BookID isn't empty");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something is wrong !! Please check again" + ex.Message);
            }
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text.Trim();
            List<Book> books = bookService.SearchBook(search);

            dgBook.ItemsSource = books;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuForm book = new MenuForm();
            book.Show();
            this.Hide();
        }
    }
}