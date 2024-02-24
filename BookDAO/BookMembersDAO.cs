using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookObject.Models;

namespace BookDAO
{
    public class BookMembersDAO
    {
        private static BookMembersDAO instance = null;

        public BookMembersDAO()
        {
        }



        public static BookMembersDAO Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new BookMembersDAO();
                }
                return instance;
            }

        }

        public List<BookManagementMember> GetBookMembers()
        {
            try
            {
                var dbContent = new BookManagementContext();
                /*return dbContent.Books.Include(c => c.BookCategory).ToList();*/
                return dbContent.BookManagementMembers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BookManagementMember GetBookMemberByID(string memberId)
        {
            try
            {
                var dbContent = new BookManagementContext();
                return dbContent.BookManagementMembers.SingleOrDefault(m => m.MemberId.Equals(memberId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddBookMember(BookManagementMember bookMember)
        {
            try
            {
                var dbContent = new BookManagementContext();
                BookManagementMember bookProfile = GetBookMemberByID(bookMember.MemberId);
                if (bookProfile == null)
                {
                    dbContent.BookManagementMembers.Add(bookMember);
                    dbContent.SaveChanges();
                }
                else
                {
                    throw new Exception("MemberID has existed !");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void DeleteMember(string memberID)
        {
            try
            {
                var dbContent = new BookManagementContext();
                BookManagementMember bookProfile = GetBookMemberByID(memberID);
                if (memberID != null)
                {
                    dbContent.BookManagementMembers.Remove(bookProfile);
                    dbContent.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void UpdateMemberProfile(BookManagementMember member)
        {
            var dbContent = new BookManagementContext();

            if (member != null)
            {
                dbContent.BookManagementMembers.Update(member);
                dbContent.SaveChanges();
            }
            else
            {
                throw new Exception("MemberID hasn't existed !");
            }
        }

        public List<BookManagementMember> SearchMember(string name)
        {
            try
            {
                using (var dbContext = new BookManagementContext())
                {
                    return dbContext.BookManagementMembers  .Where(p => p.FullName.Contains(name)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
