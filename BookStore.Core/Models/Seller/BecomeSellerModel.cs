using System.ComponentModel.DataAnnotations;
using static BookStore.Infrastructure.Data.Constants.DataConstants;
namespace BookStore.Core.Models.Seller
{
    public class BecomeSellerModel
    {
        [Required]
        [StringLength(SellerMaximumPhoneLenght, MinimumLength = SellerMinimumPhoneLenght)]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(SellerMaximumNameLenght, MinimumLength = SellerMinimumNameLenght)]
        [Display(Name = "Your Name")]
        public string Name { get; set; } = string.Empty;
    }
}
