using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Stories.Models
{
    public class StoriesTable
    {
        [Key]public int StoryId { get; set; }

        public string StoryTitle { get; set; } = null!;
        public string StoryBody { get; set; } = null!;

        [DataType(DataType.DateTime)] public DateTime StoryCreatedAt { get; set; } = DateTime.Now;
        [DataType(DataType.DateTime)] public DateTime StoryUpdatedAt { get; set; } = DateTime.Now;

    }
}
