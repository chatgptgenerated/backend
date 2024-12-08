using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class FileModel : IdentityUser
    {
        // TOOD add owner and shit
    public int Id { get; set; }
    public string Name { get; set; }
    public byte[] Data { get; set; } // Store file data here
    }
}
