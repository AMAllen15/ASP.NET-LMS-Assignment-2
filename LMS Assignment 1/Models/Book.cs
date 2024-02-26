using System.ComponentModel.DataAnnotations;

namespace LMS_Assignment_1.Models
{
    public class Book
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public bool IsAvailable { get; set; }
    }
}
