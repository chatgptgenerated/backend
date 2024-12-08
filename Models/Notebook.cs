using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Notebook
    {
        [Key]
        public int NotebookId { get; set; }
        public string NotebookName { get; set; }
    }
}
