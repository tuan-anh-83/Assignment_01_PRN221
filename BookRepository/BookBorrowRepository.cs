using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDAO;
using BookObject.Models;

namespace BookRepository
{
    public class BookBorrowRepository : IBookBorrowRepository
    {
        public void AddBookBorrow(BookBorrow book) => BookBorrowDAO.Instance.AddBookBorrow(book);

        public void DeleteBookBorrow(string bookId) => BookBorrowDAO.Instance.DeleteBookBorrow(bookId);


        public BookBorrow GetBookBorrowByID(string bookId) => BookBorrowDAO.Instance.GetBookBorrowByID(bookId);


        public List<BookBorrow> GetBookBorrows() => BookBorrowDAO.Instance.GetBooksBorrow();

        public List<BookBorrow> SearchMember(string name) => BookBorrowDAO.Instance.SearchMember(name);


        public void UpdateBookBorrow(BookBorrow book) => BookBorrowDAO.Instance.UpdateBookBorrow(book);

    }
}
