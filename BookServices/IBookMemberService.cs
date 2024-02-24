using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookObject.Models;

namespace BookServices
{
    public interface IBookMemberService
    {
        List<BookManagementMember> GetBookMembers();

        BookManagementMember GetBookMemberByID(string memberId);

        void AddBookMember(BookManagementMember bookMember);

        void DeleteMember(string memberID);

        void UpdateMemberProfile(BookManagementMember member);

        List<BookManagementMember> SearchMember(string name);
    }
}
