using System.ComponentModel.DataAnnotations;
using VampireMedia.Enums;

namespace VampireMedia.Models
{
    public class MoviesModel
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? AlsoKnownAs { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Director { get; set; }
        public MediaType? MediaType { get; set; }
        public string? Language { get; set; }
        public string? StarActor { get; set; }
        public string? SupportingActors { get;set; }
        public byte? CoverImage { get; set; }
        public RatingType Rating { get; set; }
    }
}
