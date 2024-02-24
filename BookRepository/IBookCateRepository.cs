using BookObject.Models;

namespace BookRepository
{
    public interface IBookCateRepository
    {
        List<BookCategory> GetBookCate();
        void AddBookCate(BookCategory book);

        BookCategory GetBookCateByID(string bookId);

        void DeleteBookCate(string bookId);

        void UpdateBookCate(BookCategory book);

        List<BookCategory> SearchBookCate(string name);
    }
}
