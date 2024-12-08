using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Trebuie sa introduceti prenumele!")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Trebuie sa introduceti numele de familie!")]
        public string? LastName { get; set; }

        // TODO see if it is required
        [Required]
        // attribute that a helpee gives to a helper to add him
        public string? ProfileToken {get; set;}

        [Required]
        public string? PreferedLanguage {get; set;}

    }
}
