using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookObject.Models;

namespace BookDAO
{
    public class BookCateDAO
    {
        private static BookCateDAO instance = null;

        public BookCateDAO()
        {
        }



        public static BookCateDAO Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new BookCateDAO();
                }
                return instance;
            }

        }

        public List<BookCategory> GetBookCate()
        {
            try
            {
                var dbContent = new BookManagementContext();
                /*return dbContent.Books.Include(c => c.BookCategory).ToList();*/
                return dbContent.BookCategories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BookCategory GetBookCateByID(string bookId)
        {
            try
            {
                var dbContent = new BookManagementContext();
                return dbContent.BookCategories.SingleOrDefault(m => m.BookCategoryId.Equals(bookId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddBookCate(BookCategory book)
        {
            try
            {
                var dbContent = new BookManagementContext();
                BookCategory bookProfile = GetBookCateByID(book.BookCategoryId);
                if (bookProfile == null)
                {
                    dbContent.BookCategories.Add(book);
                    dbContent.SaveChanges();
                }
                else
                {
                    throw new Exception("BookCategoryID has existed !");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void DeleteBookCate(string bookId)
        {
            try
            {
                var dbContent = new BookManagementContext();
                BookCategory bookProfile = GetBookCateByID(bookId);
                if (bookId != null)
                {
                    dbContent.BookCategories.Remove(bookProfile);
                    dbContent.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void UpdateBookCate(BookCategory book)
        {
            var dbContent = new BookManagementContext();

            if (book != null)
            {
                dbContent.BookCategories.Update(book);
                dbContent.SaveChanges();
            }
            else
            {
                throw new Exception("BookCategoryID hasn't existed !");
            }
        }

        public List<BookCategory> SearchBookCate(string book)
        {
            try
            {
                using (var dbContext = new BookManagementContext())
                {
                    return dbContext.BookCategories.Where(p => p.BookGenreType.Contains(book)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
