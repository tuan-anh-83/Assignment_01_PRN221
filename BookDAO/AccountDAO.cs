using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookObject.Models;

namespace BookDAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;

        public AccountDAO()
        {
        }

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        public BookManagementMember GetBookById(String id)
        {
            try
            {
                var dbContent = new BookManagementContext();
                return dbContent.BookManagementMembers.SingleOrDefault(m => m.MemberId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}
