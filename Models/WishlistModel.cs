using VampireMedia.Enums;

namespace VampireMedia.Models
{
    public class WishlistModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime YearReleaased  {get; set; }
        public string? LocationSeen { get; set; }
        public string? UrlToOnlineLocation { get; set; }
        public decimal Cost { get; set; }

        public MediaType MediaType { get; set; }
        public string? Description { get; set; }
    }
}
