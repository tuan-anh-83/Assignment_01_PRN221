using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDAO;
using BookObject.Models;

namespace BookRepository
{
    public class BooksRepository : IBookRepository
    {
        public void AddBookProfile(Book book) => BooksDAO.Instance.AddBookProfile(book);

        public void DeleteBookProfile(string bookId) => BooksDAO.Instance.DeleteBookProfile(bookId);
        

        public Book GetBookProfileByID(string bookId) => BooksDAO.Instance.GetBookProfileByID(bookId);
        

        public List<Book> GetBooks() => BooksDAO.Instance.GetBooks();

        public List<Book> SearchBook(string book) => BooksDAO.Instance.SearchBook(book);
        

        public void UpdateBookProfile(Book book) => BooksDAO.Instance.UpdateBookProfile(book);


        
    }
}
