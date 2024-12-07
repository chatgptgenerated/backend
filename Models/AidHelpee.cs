using System.ComponentModel.DataAnnotations.Schema;

using backend.Models;

namespace backend.Models
{
    public class AidHelpee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? HelpingProfileId { get; set; }
        public string? HelpedProfileId { get; set; }

        public virtual ApplicationUser? HelpingProfile { get; set; }
        public virtual ApplicationUser? HelpedProfile { get; set; }
    }
}
