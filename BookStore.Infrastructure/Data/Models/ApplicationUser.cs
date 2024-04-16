using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        [PersonalData]
        public string? FirstName { get; set; }
        [PersonalData]
        public string? LastName { get; set; }

        public bool IsActive { get; set; } = true;
        public Seller? Seller { get; set; }
    }
}
