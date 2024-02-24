using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookObject.Models;

namespace BookServices
{
    public interface IBookService
    {
        List<Book> GetBooks();
        void AddBookProfile(Book book);

        Book GetBookProfileByID(string bookId);

        void DeleteBookProfile(string bookId);

        void UpdateBookProfile(Book book);

        List<Book> SearchBook(string book);
    }
}
