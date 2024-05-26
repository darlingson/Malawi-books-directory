using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Malawi_books_directory.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Title { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [StringLength(50)]
        public string? Genre { get; set; }

        [StringLength(13)]
        public string? ISBN { get; set; }

        [StringLength(100)]
        public string? Publisher { get; set; }

        [StringLength(50)]
        public string? Language { get; set; }

        public int NumberOfPages { get; set; }

        [Url]
        public string? CoverImageUrl { get; set; }

        [StringLength(200)]
        public string? Tags { get; set; }

        public List<Review>? Reviews { get; set; }
    }
}
