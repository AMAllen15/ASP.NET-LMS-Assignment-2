
using LMS_Assignment_1.Models;
using LMS_Assignment_1.Data;

namespace LMS_Assignment_1.Data
{
    public static class DataRepository
{
    public static List<Book> BookList = new List<Book>();
    public static List<Reader> ReaderList = new List<Reader>();
    public static List<Borrowing> BorrowingList = new List<Borrowing>();

        // Populate some initial data for testing
        static DataRepository()
        {
            
            BookList.Add(new Book { Id = 5001, Title = "The Great Gatsby", IsAvailable = true });
            BookList.Add(new Book { Id = 5002, Title = "To Kill a Mockingbird", IsAvailable = true });

            ReaderList.Add(new Reader { Id = 101, Name = "Alice Johnson", Email = "alice.j@example.com" });
            ReaderList.Add(new Reader { Id = 102, Name = "Bob Thompson", Email = "bob.t@example.com" });

            BorrowingList.Add(new Borrowing { Id = 1, BookId = 1, ReaderId = 1, BorrowDate = DateTime.UtcNow.AddDays(-7), IsReturned = false });
            BorrowingList.Add(new Borrowing { Id = 2, BookId = 2, ReaderId = 2, BorrowDate = DateTime.UtcNow.AddDays(-14), IsReturned = false });
        }
    }
}
