using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Stories.Models
{
    public class ParagraphsTable
    {
        public int ParagraphId { get; set; }

        public string Paragraphs { get; set; } = null!;


        [DataType(DataType.DateTime)] public DateTime CreatedAt { get; set; } = DateTime.Now;
        [DataType(DataType.DateTime)] public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Foreign Key
        public int StoryId { get; set; }
        public StoriesTable StoriesTable { get; set; } = null!;

    }
}
