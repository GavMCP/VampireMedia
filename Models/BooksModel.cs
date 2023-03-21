using System.ComponentModel.DataAnnotations;
using VampireMedia.Enums;

namespace VampireMedia.Models
{
    public class BooksModel
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        [DataType(DataType.Date)]
        public DateTime? YearPublished { get; set; }

        public BookType BookType { get; set; }
        public string? Description { get; set; }
        public byte? CoverImage { get; set; }
        public RatingType Rating { get; set; }
        public int? Edition { get; set; }
    }
}
