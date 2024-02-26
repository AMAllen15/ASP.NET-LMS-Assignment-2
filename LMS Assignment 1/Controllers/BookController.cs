using Microsoft.AspNetCore.Mvc;
using LMS_Assignment_1.Models;
using LMS_Assignment_1.Data;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllBooks()
    {
        return Ok(DataRepository.BookList);
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        var book = DataRepository.BookList.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound(); // 404 Not Found
        }

        return Ok(book);
    }

    [HttpPost]
    public IActionResult CreateBook([FromBody] Book book)
    {
        book.Id = DataRepository.BookList.Count + 1;
        DataRepository.BookList.Add(book);
        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
    {
        var book = DataRepository.BookList.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound(); // 404 Not Found
        }

        book.Title = updatedBook.Title;
        book.IsAvailable = updatedBook.IsAvailable;

        return NoContent(); // 204 No Content
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = DataRepository.BookList.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound(); // 404 Not Found
        }

        DataRepository.BookList.Remove(book);

        return NoContent(); // 204 No Content
    }
}

