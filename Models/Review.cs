using System;
using System.ComponentModel.DataAnnotations;

namespace Malawi_books_directory.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }

        [StringLength(100)]
        public string? ReviewerName { get; set; }

        [StringLength(1000)]
        public string? ReviewText { get; set; }

        public int Rating { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReviewDate { get; set; }
    }
}
