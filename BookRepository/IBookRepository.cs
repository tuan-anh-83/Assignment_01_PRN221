using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookObject.Models;

namespace BookRepository
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        void AddBookProfile(Book book);

        Book GetBookProfileByID(string bookId);

        void DeleteBookProfile(string bookId);

        void UpdateBookProfile(Book book);

        List<Book> SearchBook(string book);
    }
}
