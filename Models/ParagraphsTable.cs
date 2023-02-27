using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stories.Models
{
    public class ParagraphsTable
    {
        [Key]public int ParagraphId { get; set; }

        public string ParagraphText { get; set; } = null!;

        // Foreign Key
        public int StoryId { get; set; }

        [ForeignKey("StoryId")]
        public StoriesTable StoriesTable { get; set; } = null!;

    }
}
