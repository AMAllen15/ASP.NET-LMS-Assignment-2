using System.ComponentModel.DataAnnotations;

namespace LMS_Assignment_1.Models
{
    public class Borrowing
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "ReaderId is required")]
        public int ReaderId { get; set; }

        [Required(ErrorMessage = "BookId is required")]
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
