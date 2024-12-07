using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public bool isPrivate { get; set; }
        [Required(ErrorMessage = "Trebuie sa introduceti prenumele!")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Trebuie sa introduceti numele de familie!")]
        public string? LastName { get; set; }

    }
}
