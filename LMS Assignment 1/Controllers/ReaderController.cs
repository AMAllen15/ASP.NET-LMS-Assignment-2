using Microsoft.AspNetCore.Mvc;
using LMS_Assignment_1.Models;
using LMS_Assignment_1.Data;

[ApiController]
[Route("api/[controller]")]
public class ReaderController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllReaders()
    {
        return Ok(DataRepository.ReaderList);
    }

    [HttpGet("{id}")]
    public IActionResult GetReaderById(int id)
    {
        var reader = DataRepository.ReaderList.FirstOrDefault(r => r.Id == id);
        if (reader == null)
        {
            return NotFound(); // 404 Not Found
        }

        return Ok(reader);
    }

    [HttpPost]
    public IActionResult CreateReader([FromBody] Reader reader)
    {
        reader.Id = 100 + DataRepository.ReaderList.Count + 1;
        DataRepository.ReaderList.Add(reader);
        return CreatedAtAction(nameof(GetReaderById), new { id = reader.Id }, reader);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateReader(int id, [FromBody] Reader updatedReader)
    {
        var reader = DataRepository.ReaderList.FirstOrDefault(r => r.Id == id);
        if (reader == null)
        {
            return NotFound(); // 404 Not Found
        }

        reader.Name = updatedReader.Name;
        reader.Email = updatedReader.Email;

        return NoContent(); // 204 No Content
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteReader(int id)
    {
        var reader = DataRepository.ReaderList.FirstOrDefault(r => r.Id == id);
        if (reader == null)
        {
            return NotFound(); // 404 Not Found
        }

        DataRepository.ReaderList.Remove(reader);

        // Return a success message
        return Ok(new { message = "Reader successfully removed" });
    }
}