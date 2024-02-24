using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookObject.Models;
using BookServices;

namespace SE160143_Ass1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAccountService accountService;
        public MainWindow()
        {
            InitializeComponent();
            accountService = new AccountService();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BookManagementMember account = accountService.GetBookById(txtUsername.Text.Trim());
                if (account != null && txtPassword.Text.Trim().Equals(account.Password))
                {
                    switch (account.MemberRole)
                    {
                        case 1:
                            MenuForm book = new MenuForm();
                            book.Show();
                            this.Hide();
                            break;
                        case 2:
                            ListBooksForMem list = new ListBooksForMem();
                            list.Show();
                            this.Hide();
                            break;
                        case 3:
                            BookBorrowManagementForm bookBorrow = new BookBorrowManagementForm();
                            bookBorrow.Show();
                            this.Hide();
                            break;
                        default:
                            MessageBox.Show("You are not Permission !");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Please check your username or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }


        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}