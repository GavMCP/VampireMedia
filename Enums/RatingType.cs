using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VampireMedia.Enums
{
    public enum RatingType
    {
        [Display(Name = "1* - Rubbish")]
        OneStar = 1,
        [Display(Name = "2* - Below Average")]
        TwoStars = 2,
        [Display(Name = "3* - Average")]
        ThreeStars = 3,
        [Display(Name = "4* - Good")]
        FourStars = 4,
        [Display(Name = "5* - Excellent")]
        FiveStars = 5

    }
}
