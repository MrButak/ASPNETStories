using System.ComponentModel.DataAnnotations;

namespace Stories.Models
{
    public class ParagraphsTable
    {
        [Key]public int ParagraphId { get; set; }

        public string ParagraphText { get; set; } = null!;

        // Foreign Key
        public int StoryId { get; set; }
        public StoriesTable StoriesTable { get; set; } = null!;


    }
}
