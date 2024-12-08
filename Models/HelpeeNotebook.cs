using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class HelpeeNotebook
    {
        [Key]
        public int Id { get; set; }
        public string HelpeeId { get; set; }
        public int NotebookId { get; set; }
    }
}
