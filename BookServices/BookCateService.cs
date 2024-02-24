using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookObject.Models;
using BookRepository;

namespace BookServices
{
    public class BookCateService : IBookCateService
    {
        private IBookCateRepository bookCateRepository = null;

        public BookCateService()
        {
            bookCateRepository = new BookCateRepository();
        }
        public void AddBookCate(BookCategory book)
        {
            bookCateRepository.AddBookCate(book);
        }

        public void DeleteBookCate(string bookId)
        {
            bookCateRepository.DeleteBookCate(bookId);
        }

        public List<BookCategory> GetBookCate()
        {
            return bookCateRepository.GetBookCate();
        }

        public BookCategory GetBookCateByID(string bookId)
        {
            return bookCateRepository.GetBookCateByID(bookId);
        }

        public List<BookCategory> SearchBookCate(string name)
        {
            return bookCateRepository.SearchBookCate(name);
        }

        public void UpdateBookCate(BookCategory book)
        {
            bookCateRepository.UpdateBookCate(book);
        }
    }
}
