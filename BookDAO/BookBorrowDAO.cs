using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookObject.Models;

namespace BookDAO
{
    public class BookBorrowDAO
    {
        private static BookBorrowDAO instance = null;

        public BookBorrowDAO()
        {
        }



        public static BookBorrowDAO Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new BookBorrowDAO();
                }
                return instance;
            }

        }

        public List<BookBorrow> GetBooksBorrow()
        {
            try
            {
                var dbContent = new BookManagementContext();
                /*return dbContent.Books.Include(c => c.BookCategory).ToList();*/
                return dbContent.BookBorrows.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BookBorrow GetBookBorrowByID(string bookId)
        {
            try
            {
                var dbContent = new BookManagementContext();
                return dbContent.BookBorrows.SingleOrDefault(m => m.BookBorrowId.Equals(bookId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddBookBorrow(BookBorrow book)
        {
            try
            {
                var dbContent = new BookManagementContext();
                BookBorrow bookProfile = GetBookBorrowByID(book.BookBorrowId);
                if (bookProfile == null)
                {
                    dbContent.BookBorrows.Add(book);
                    dbContent.SaveChanges();
                }
                else
                {
                    throw new Exception("BookBorrowID has existed !");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void DeleteBookBorrow(string bookId)
        {
            try
            {
                var dbContent = new BookManagementContext();
                BookBorrow bookProfile = GetBookBorrowByID(bookId);
                if (bookId != null)
                {
                    dbContent.BookBorrows.Remove(bookProfile);
                    dbContent.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void UpdateBookBorrow(BookBorrow book)
        {
            var dbContent = new BookManagementContext();

            if (book != null)
            {
                dbContent.BookBorrows.Update(book);
                dbContent.SaveChanges();
            }
            else
            {
                throw new Exception("BookBorrowID hasn't existed !");
            }
        }

        public List<BookBorrow> SearchMember(string name)
        {
            try
            {
                using (var dbContext = new BookManagementContext())
                {
                    return dbContext.BookBorrows.Where(p => p.BookBorrowId.Contains(name)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
