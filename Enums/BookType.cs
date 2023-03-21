using System.ComponentModel.DataAnnotations;

namespace VampireMedia.Enums
{
    public enum BookType
    {
        [Display(Name = "Hardback")]
        HardBack = 1,
        [Display(Name = "Softback")]
        SoftBack = 2,
        [Display(Name = "Magazine")]
        Magazine = 3,
        [Display(Name = "Other")]
        Other = 4
         
    }
}
