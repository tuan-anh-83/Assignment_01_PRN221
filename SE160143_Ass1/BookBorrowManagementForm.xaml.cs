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
    /// Interaction logic for BookBorrowManagementForm.xaml
    /// </summary>
    public partial class BookBorrowManagementForm : Window
    {
        private IBookBorrowService bookBorrowService = null;

        private IAccountService accountService = null;
        public BookBorrowManagementForm()
        {
            InitializeComponent();
            bookBorrowService = new BookBorrowService();
            accountService = new AccountService();

            dgBookBorrow.ItemsSource = bookBorrowService.GetBookBorrows();

            dgBookBorrow.AddHandler(DataGridCell.MouseLeftButtonDownEvent, new MouseButtonEventHandler(DataGrid_CellMouseLeftButtonDown), true);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValidData = true;
            if (!BookUtils.isNotEmpty(txtBookBorrowID.Text.Trim()))
            {
                isValidData = false;
                txtBookBorrowID.Focus();
                txtBookBorrowID.Background = Brushes.Red; ;
                MessageBox.Show("BookBorrowID can not Empty !");
            }

            try
            {
                if (isValidData)
                {
                    BookBorrow book = new BookBorrow();
                    book.BookBorrowId = txtBookBorrowID.Text.Trim();
                    book.BookId = txtBookID.Text.Trim();
                    book.ReturnDate = DateTime.Parse(dtReturnDay.Text.Trim());
                    book.BorrowDate = DateTime.Parse(dtBorrowDay.Text.Trim());
                    book.MemberId = txtMemberID.Text.Trim();


                    bookBorrowService.AddBookBorrow(book);
                    MessageBox.Show("Add BookBorrow Successfull !!");
                    dgBookBorrow.ItemsSource = bookBorrowService.GetBookBorrows();
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
            var selectedBook = (BookBorrow)row.Item;
            txtBookBorrowID.Text = selectedBook.BookBorrowId;
            txtBookID.Text = selectedBook.BookId;
            dtBorrowDay.SelectedDate = selectedBook.BorrowDate;
            dtReturnDay.SelectedDate = selectedBook.ReturnDate;
            txtMemberID.Text = selectedBook.MemberId;
            
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BookBorrow book = bookBorrowService.GetBookBorrowByID(txtBookID.Text.Trim());

                if (bookBorrowService != null)
                {
                    book.BookBorrowId = txtBookBorrowID.Text.Trim();
                    book.BookId = txtBookID.Text.Trim();
                    book.ReturnDate = DateTime.Parse(dtReturnDay.Text.Trim());
                    book.BorrowDate = DateTime.Parse(dtBorrowDay.Text.Trim());
                    book.MemberId = txtMemberID.Text.Trim();

                    bookBorrowService.UpdateBookBorrow(book);
                    MessageBox.Show("Update Book Successfull !!");
                    dgBookBorrow.ItemsSource = bookBorrowService.GetBookBorrows();
                }
                else
                {
                    MessageBox.Show("BookBorrowID isn't existed!");
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
                if (txtBookBorrowID.Text.Length > 0)
                {
                    bookBorrowService.DeleteBookBorrow(txtBookBorrowID.Text.Trim());
                    MessageBox.Show("Delete Book Successfull !!");
                    dgBookBorrow.ItemsSource = bookBorrowService.GetBookBorrows();
                }
                else
                {
                    MessageBox.Show("BookBorrowID isn't empty");
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
                List<BookBorrow> books = bookBorrowService.SearchMember(search);

                dgBookBorrow.ItemsSource = books;
           
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuForm book = new MenuForm();
            book.Show();
            this.Hide();
        }
    }
}
