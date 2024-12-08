using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class FileNotebook
    {
        [Key]
        public int Id { get; set; }
        public int FileId { get; set; }
        public string NotebookId { get; set; }
    }
}
