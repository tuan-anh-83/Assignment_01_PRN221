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
    /// Interaction logic for BookMemberForm.xaml
    /// </summary>
    public partial class BookMemberForm : Window
    {
        private IBookMemberService bookService = null;

        private IAccountService accountService = null;
        public BookMemberForm()
        {
            InitializeComponent();
            bookService = new BookMemberService();
            accountService = new AccountService();
            /*dgBook.ItemsSource = bookService.GetBooks().Select(c => new{c.BookId, c.BookName, c.Description, c.ReleaseDate, c.Quantity, c.Price, c.Author, c.BookCategoryId}).ToList();*/
            dgMemberList.ItemsSource = bookService.GetBookMembers();

            dgMemberList.AddHandler(DataGridCell.MouseLeftButtonDownEvent, new MouseButtonEventHandler(DataGrid_CellMouseLeftButtonDown), true);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValidData = true;
            if (!BookUtils.isNotEmpty(txtMemberID.Text.Trim()))
            {
                isValidData = false;
                txtMemberID.Focus();
                txtMemberID.Background = Brushes.Red; ;
                MessageBox.Show("MemberID can not Empty !");
            }

            try
            {
                if (isValidData)
                {
                    BookManagementMember book = new BookManagementMember();
                    book.MemberId = txtMemberID.Text.Trim();
                    book.Email = txtEmail.Text.Trim();
                    book.FullName = txtFullName.Text.Trim();
                    book.Password = txtPassword.Text.Trim();
                    book.MemberRole = int.Parse(txtMemberRole.Text.Trim());

                    bookService.AddBookMember(book);
                    MessageBox.Show("Add Book Successfull !!");
                    dgMemberList.ItemsSource = bookService.GetBookMembers();
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
            var selectedBook = (BookManagementMember)row.Item;
            txtMemberID.Text = selectedBook.MemberId;
            txtPassword.Text = selectedBook.Password;
            txtEmail.Text = selectedBook.Email;
            txtFullName.Text = selectedBook.FullName;
            txtMemberRole.Text = selectedBook.MemberRole.ToString();


            //txtBookID.IsReadOnly = true;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BookManagementMember book = bookService.GetBookMemberByID(txtMemberID.Text.Trim());

                if (bookService != null)
                {

                    book.MemberId = txtMemberID.Text.Trim();
                    book.Email = txtEmail.Text.Trim();
                    book.FullName = txtFullName.Text.Trim();
                    book.Password = txtPassword.Text.Trim();
                    book.MemberRole = int.Parse(txtMemberRole.Text.Trim());

                    bookService.UpdateMemberProfile(book);
                    MessageBox.Show("Update Member Successfull !!");
                    dgMemberList.ItemsSource = bookService.GetBookMembers();
                }
                else
                {
                    MessageBox.Show("MemberID isn't existed!");
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
                if (txtMemberID.Text.Length > 0)
                {
                    bookService.DeleteMember(txtMemberID.Text.Trim());
                    MessageBox.Show("Delete Member Successfull !!");
                    dgMemberList.ItemsSource = bookService.GetBookMembers();
                }
                else
                {
                    MessageBox.Show("MemberID isn't empty");
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
            List<BookManagementMember> books = bookService.SearchMember(search);

            dgMemberList.ItemsSource = books;

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuForm book = new MenuForm();
            book.Show();
            this.Hide();
        }
    }
}
