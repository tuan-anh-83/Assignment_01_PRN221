using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDAO;
using BookObject.Models;

namespace BookRepository
{
    public class AccountRepository : IAccountRepository
    {
        public BookManagementMember GetBookById(string id) => AccountDAO.Instance.GetBookById(id);
    }
}
