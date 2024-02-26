using LMS_Assignment_1.Data;
using LMS_Assignment_1.Models;
using Microsoft.AspNetCore.Mvc;


namespace LMS_Assignment_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowingController : ControllerBase
    {
        // GET: api/Borrowing
        [HttpGet]
        
        public IActionResult GetBorrowings()
        {
            return Ok(DataRepository.BorrowingList);
        }

        [HttpGet("{id}")]
        public IActionResult GetBorrowings(int id)
        {
            var book = DataRepository.BorrowingList.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound(); // 404 Not Found
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBorrowing([FromBody] Borrowing borrowing)
        {
            // Check if the book is available
            var book = DataRepository.BookList.FirstOrDefault(b => b.Id == borrowing.BookId);
            if (book == null || !book.IsAvailable)
            {
                return BadRequest(new { message = "Book is not available for borrowing" });
            }

            // Check if the reader exists
            var reader = DataRepository.ReaderList.FirstOrDefault(r => r.Id == borrowing.ReaderId);
            if (reader == null)
            {
                return BadRequest(new { message = "Reader not found" });
            }

            // Create new borrowing
            borrowing.Id = DataRepository.BorrowingList.Count + 1;
            borrowing.BorrowDate = DateTime.UtcNow;
            borrowing.IsReturned = false;
            DataRepository.BorrowingList.Add(borrowing);

            // Update book availability
            book.IsAvailable = false;

            // Return the created borrowing
            return Ok(new { message = "Borrowing created successfully", borrowing });
        }

        // PUT: api/Borrowing/5
        [HttpPut("{id}")]
        public IActionResult UpdateBorrowing(int id, [FromBody] Borrowing updatedBorrowing)
        {
            // Find existing borrowing
            var existingBorrowing = DataRepository.BorrowingList.FirstOrDefault(b => b.Id == id);
            if (existingBorrowing == null)
            {
                return NotFound(new { message = "Borrowing not found" });
            }

            // Check if the book is available
            var book = DataRepository.BookList.FirstOrDefault(b => b.Id == updatedBorrowing.BookId);
            if (book == null || !book.IsAvailable)
            {
                return BadRequest(new { message = "Book is not available for borrowing" });
            }

            // Check if the reader exists
            var reader = DataRepository.ReaderList.FirstOrDefault(r => r.Id == updatedBorrowing.ReaderId);
            if (reader == null)
            {
                return BadRequest(new { message = "Reader not found" });
            }

            // Update borrowing details
            existingBorrowing.ReaderId = updatedBorrowing.ReaderId;
            existingBorrowing.BookId = updatedBorrowing.BookId;

            // Update book availability
            book.IsAvailable = false;

            // Return the updated borrowing
            return Ok(new { message = "Borrowing updated successfully", existingBorrowing });
        }

        // DELETE: api/Borrowing/5
        [HttpDelete("{id}")]
        public IActionResult CancelBorrowing(int id)
        {
            // Find existing borrowing
            var existingBorrowing = DataRepository.BorrowingList.FirstOrDefault(b => b.Id == id);
            if (existingBorrowing == null)
            {
                return NotFound(new { message = "Borrowing not found" });
            }

            // Update book availability
            var book = DataRepository.BookList.FirstOrDefault(b => b.Id == existingBorrowing.BookId);
            if (book != null)
            {
                book.IsAvailable = true;
            }

            // Remove borrowing from the list
            DataRepository.BorrowingList.Remove(existingBorrowing);

            // Return a success message
            return Ok(new { message = "Borrowing canceled successfully" });
        }
    }
}
    
