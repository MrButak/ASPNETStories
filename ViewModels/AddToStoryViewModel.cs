using Stories.Models;
using System.ComponentModel.DataAnnotations;

namespace Stories.ViewModels
{
    public class AddToStoryViewModel
    {
        [Required(ErrorMessage = "Please add at least one paragraph")]
        [Display(Name = "Story Text")]
        public string NewParagraphText { get; set; } = null!;
        public StoriesTable? StoryWithParagraphs { get; set; }
    }
}
