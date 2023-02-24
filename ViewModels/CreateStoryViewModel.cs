using System.ComponentModel.DataAnnotations;

namespace Stories.ViewModels
{
    public class CreateStoryViewModel
    {
        [Required(ErrorMessage = "Please give your story a title")]
        [Display(Name = "Story Title")]
        [MaxLength(255)]
        public string StoryTitle { get; set; } = null!;

        [Required(ErrorMessage = "Please give your story at least one paragraph")]
        [Display(Name = "Story Text")]
        public string ParagraphText { get; set; } = null!;
    }
}
