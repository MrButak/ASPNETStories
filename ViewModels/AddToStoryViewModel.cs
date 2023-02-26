using System.ComponentModel.DataAnnotations;

namespace Stories.ViewModels
{
    public class AddToStoryViewModel
    {
        [Required(ErrorMessage = "Please add at least one paragraph")]
        [Display(Name = "Story Text")]
        public string ParagraphText { get; set; } = null!;

        public List<Stories.Models.ParagraphsTable> StoryWithAllParagraphs { get; set; } = null!;
        public string MyStr { get; set; } = null!;
    }
}
