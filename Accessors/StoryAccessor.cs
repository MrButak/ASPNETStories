using Stories.Data;
using Stories.Models;

namespace Stories.Accessors
{
    public class StoryAccessor
    {

        private readonly StoriesContext _context;

        public StoryAccessor(StoriesContext context)
        {
            _context = context;
        }

        public static bool CreateStory(string StoryTitle, string ParagraphText, Stories.Data.StoriesContext _context)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var story = new StoriesTable { StoryTitle = StoryTitle };
                    _context.Add(story);
                    _context.SaveChanges();

                    var paragraph = new ParagraphsTable
                    {
                        ParagraphText = ParagraphText,
                        StoryId = story.StoryId
                    };
                    _context.Add(paragraph);
                    _context.SaveChanges();

                    transaction.Commit();

                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }

        }
    }
}
