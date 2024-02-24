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
using BookServices;

namespace SE160143_Ass1
{
    /// <summary>
    /// Interaction logic for MenuForm.xaml
    /// </summary>
    public partial class MenuForm : Window
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnBookManagement_Click(object sender, RoutedEventArgs e)
        {
            BookManagementForm bookMana = new BookManagementForm();
            bookMana.Show();
            this.Hide();

        }

        private void btnBookBorrow_Click(object sender, RoutedEventArgs e)
        {
            BookBorrowManagementForm bookBorrow = new BookBorrowManagementForm();
            bookBorrow.Show();
            this.Hide();
        }

        private void btnBookMembers_Click(object sender, RoutedEventArgs e)
        {
            BookMemberForm bookMember = new BookMemberForm();
            bookMember.Show();
            this.Hide();
        }

        private void btnBookCate_Click(object sender, RoutedEventArgs e)
        {
            BookCateManagement bookMember = new BookCateManagement();
            bookMember.Show();
            this.Hide();
        }
    }
}
