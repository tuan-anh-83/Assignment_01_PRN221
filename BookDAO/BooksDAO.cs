using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookObject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookDAO
{
    public class BooksDAO
    {
        private static BooksDAO instance = null;

        public BooksDAO()
        {
        }



        public static BooksDAO Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new BooksDAO();
                }
                return instance;
            }

        }

        public List<Book> GetBooks()
        {
            try
            {
                var dbContent = new BookManagementContext();
                /*return dbContent.Books.Include(c => c.BookCategory).ToList();*/
                return dbContent.Books.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Book GetBookProfileByID(string bookId)
        {
            try
            {
                var dbContent = new BookManagementContext();
                return dbContent.Books.SingleOrDefault(m => m.BookId.Equals(bookId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddBookProfile(Book book)
        {
            try
            {
                var dbContent = new BookManagementContext();
                Book bookProfile = GetBookProfileByID(book.BookId);
                if (bookProfile == null)
                {
                    dbContent.Books.Add(book);
                    dbContent.SaveChanges();
                }
                else
                {
                    throw new Exception("BookID has existed !");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void DeleteBookProfile(string bookId)
        {
            try
            {
                var dbContent = new BookManagementContext();
                Book bookProfile = GetBookProfileByID(bookId);
                if (bookId != null)
                {
                    dbContent.Books.Remove(bookProfile);
                    dbContent.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void UpdateBookProfile(Book book)
        {
            var dbContent = new BookManagementContext();
            
            if (book != null)
            {
                dbContent.Books.Update(book);
                dbContent.SaveChanges();
            }
            else
            {
                throw new Exception("BookID hasn't existed !");
            }
        }

        public List<Book> SearchBook(string book) 
        {
            try
            {
                using (var dbContext = new BookManagementContext())
                {
                    return dbContext.Books.Where(p => p.BookName.Contains(book)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
