using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Seller
{
    public class BecomeSellerModel
    {
        [Required]
        [StringLength(15, MinimumLength = 7)]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(3, MinimumLength = 40)]
        [Display(Name = "Your Name")]
        public string Name { get; set; } = string.Empty;
    }
}
