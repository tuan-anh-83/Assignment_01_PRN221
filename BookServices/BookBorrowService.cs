using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookObject.Models;
using BookRepository;

namespace BookServices
{
    public class BookBorrowService : IBookBorrowService
    {
        private IBookBorrowRepository bookBorrowRepository = null;

        public BookBorrowService()
        {
            bookBorrowRepository = new BookBorrowRepository();
        }
        public void AddBookBorrow(BookBorrow book)
        {
            bookBorrowRepository.AddBookBorrow(book);
        }

        public void DeleteBookBorrow(string bookId)
        {
            bookBorrowRepository.DeleteBookBorrow(bookId);
        }

        public BookBorrow GetBookBorrowByID(string bookId)
        {
            return bookBorrowRepository.GetBookBorrowByID(bookId);
        }

        public List<BookBorrow> GetBookBorrows()
        {
            return bookBorrowRepository.GetBookBorrows();
        }

        public List<BookBorrow> SearchMember(string name)
        {
            return bookBorrowRepository.SearchMember(name);
        }

        public void UpdateBookBorrow(BookBorrow book)
        {
            bookBorrowRepository.UpdateBookBorrow(book);
        }
    }
}
