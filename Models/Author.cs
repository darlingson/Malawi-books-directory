using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Malawi_books_directory.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(1000)]
        public string? Biography { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(50)]
        public string? Nationality { get; set; }

        [Url]
        public string? PhotoUrl { get; set; }

        public List<Book>? Books { get; set; }
    }
}
