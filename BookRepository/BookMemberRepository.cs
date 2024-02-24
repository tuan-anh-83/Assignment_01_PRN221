using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDAO;
using BookObject.Models;

namespace BookRepository
{
    public class BookMemberRepository : IBookMemberRepository
    {
        public void AddBookMember(BookManagementMember bookMember) => BookMembersDAO.Instance.AddBookMember(bookMember);
        

        public void DeleteMember(string memberID) => BookMembersDAO.Instance.DeleteMember(memberID);



        public BookManagementMember GetBookMemberByID(string memberId) => BookMembersDAO.Instance.GetBookMemberByID(memberId);



        public List<BookManagementMember> GetBookMembers() => BookMembersDAO.Instance.GetBookMembers();

        public List<BookManagementMember> SearchMember(string name) => BookMembersDAO.Instance.SearchMember(name);
        

        public void UpdateMemberProfile(BookManagementMember member) => BookMembersDAO.Instance.UpdateMemberProfile(member);


    }
}
