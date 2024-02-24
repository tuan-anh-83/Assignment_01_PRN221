using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookObject.Models;

namespace BookServices
{
    public interface IAccountService
    {
        BookManagementMember GetBookById(string id);
    }
}
