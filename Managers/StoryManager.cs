using Stories.Accessors;

namespace Stories.Managers
{
    public class StoryManager
    {
        public static bool CreateStory(string StoryTitle, string ParagraphText, Stories.Data.StoriesContext _context)
        {
            return StoryAccessor.CreateStory(StoryTitle, ParagraphText, _context);
        }

        /*static void Main(string[] args)
        {
            return CreateStory();
        }*/
    }

}
