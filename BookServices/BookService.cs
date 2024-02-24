using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookObject.Models;
using BookRepository;

namespace BookServices
{
    public class BookService : IBookService
    {
        private IBookRepository bookRepository = null;

        public BookService()
        {
            bookRepository = new BooksRepository();
        }

        public void AddBookProfile(Book book)
        {
            bookRepository.AddBookProfile(book);
        }

        public void DeleteBookProfile(string bookId)
        {
            bookRepository.DeleteBookProfile(bookId);
        }

        public Book GetBookProfileByID(string bookId)
        {
            return bookRepository.GetBookProfileByID(bookId);
        }

        public List<Book> GetBooks()
        {
            return bookRepository.GetBooks();
        }

        public List<Book> SearchBook(string book)
        {
            return bookRepository.SearchBook(book);
        }

        public void UpdateBookProfile(Book book)
        {
            bookRepository.UpdateBookProfile(book);
        }
    }
}
