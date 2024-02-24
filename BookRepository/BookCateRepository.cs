using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDAO;
using BookObject.Models;

namespace BookRepository
{
    public class BookCateRepository : IBookCateRepository
    {
        public void AddBookCate(BookCategory book) => BookCateDAO.Instance.AddBookCate(book);
        

        public void DeleteBookCate(string bookId) => BookCateDAO.Instance.DeleteBookCate(bookId);



        public List<BookCategory> GetBookCate() => BookCateDAO.Instance.GetBookCate();



        public BookCategory GetBookCateByID(string bookId) => BookCateDAO.Instance.GetBookCateByID(bookId);



        public List<BookCategory> SearchBookCate(string name) => BookCateDAO.Instance.SearchBookCate(name);



        public void UpdateBookCate(BookCategory book) => BookCateDAO.Instance.UpdateBookCate(book);


    }
}
