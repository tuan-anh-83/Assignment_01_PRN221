using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookObject.Models;
using BookRepository;

namespace BookServices
{
    public class BookMemberService : IBookMemberService
    {
        private IBookMemberRepository bookMemberRepository = null;

        public BookMemberService()
        {
            bookMemberRepository = new BookMemberRepository();
        }
        public void AddBookMember(BookManagementMember bookMember)
        {
            bookMemberRepository.AddBookMember(bookMember);
        }

        public void DeleteMember(string memberID)
        {
            bookMemberRepository.DeleteMember(memberID);
        }

        public BookManagementMember GetBookMemberByID(string memberId)
        {
            return bookMemberRepository.GetBookMemberByID(memberId);
        }

        public List<BookManagementMember> GetBookMembers()
        {
            return bookMemberRepository.GetBookMembers();
        }

        public List<BookManagementMember> SearchMember(string name)
        {
            return bookMemberRepository.SearchMember(name);
        }

        public void UpdateMemberProfile(BookManagementMember member)
        {
            bookMemberRepository.UpdateMemberProfile(member);
        }
    }
}
