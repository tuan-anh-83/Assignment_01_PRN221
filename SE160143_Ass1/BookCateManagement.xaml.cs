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
using BookObject.Models;
using BookObject;
using BookServices;

namespace SE160143_Ass1
{
    /// <summary>
    /// Interaction logic for BookCateManagement.xaml
    /// </summary>
    public partial class BookCateManagement : Window
    {
        private IBookCateService bookBorrowService = null;

        private IAccountService accountService = null;
        public BookCateManagement()
        {
            InitializeComponent();
            bookBorrowService = new BookCateService();
            accountService = new AccountService();

            dgBookCate.ItemsSource = bookBorrowService.GetBookCate();

            dgBookCate.AddHandler(DataGridCell.MouseLeftButtonDownEvent, new MouseButtonEventHandler(DataGrid_CellMouseLeftButtonDown), true);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValidData = true;
            if (!BookUtils.isNotEmpty(txtBookCateID.Text.Trim()))
            {
                isValidData = false;
                txtBookCateID.Focus();
                txtBookCateID.Background = Brushes.Red; ;
                MessageBox.Show("BookCategoryID can not Empty !");
            }

            try
            {
                if (isValidData)
                {
                    BookCategory book = new BookCategory();
                    book.BookCategoryId = txtBookCateID.Text.Trim();
                    book.BookGenreType = txtGenType.Text.Trim();
                    book.Description = txtDescription.Text.Trim();


                    bookBorrowService.AddBookCate(book);
                    MessageBox.Show("Add BookCategory Successfull !!");
                    dgBookCate.ItemsSource = bookBorrowService.GetBookCate();
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
            var selectedBook = (BookCategory)row.Item;
            txtBookCateID.Text = selectedBook.BookCategoryId;
            txtGenType.Text = selectedBook.BookGenreType;
            txtDescription.Text = selectedBook.Description;
            


            //txtBookID.IsReadOnly = true;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BookCategory book = bookBorrowService.GetBookCateByID(txtBookCateID.Text.Trim());

                if (bookBorrowService != null)
                {
                    book.BookCategoryId = txtBookCateID.Text.Trim();
                    book.BookGenreType = txtGenType.Text.Trim();
                    book.Description = txtDescription.Text.Trim();

                    bookBorrowService.UpdateBookCate(book);
                    MessageBox.Show("Update Book Successfull !!");
                    dgBookCate.ItemsSource = bookBorrowService.GetBookCate();
                }
                else
                {
                    MessageBox.Show("BookCategoryID isn't existed!");
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
                if (txtBookCateID.Text.Length > 0)
                {
                    bookBorrowService.DeleteBookCate(txtBookCateID.Text.Trim());
                    MessageBox.Show("Delete BookCategory Successfull !!");
                    dgBookCate.ItemsSource = bookBorrowService.GetBookCate();
                }
                else
                {
                    MessageBox.Show("BookCategoryID isn't empty");
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
            List<BookCategory> books = bookBorrowService.SearchBookCate(search);

            dgBookCate.ItemsSource = books;

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuForm book = new MenuForm();
            book.Show();
            this.Hide();
        }
    }
}
