using System.ComponentModel.DataAnnotations;

namespace VampireMedia.Enums
{
    public enum MediaType
    {
        [Display(Name = "DVD")]
        DVD = 1,
        [Display(Name = "BLU-RAY")]
        BluRay = 2,
        [Display(Name = "BOTH")]
        Both = 3
    }
}
