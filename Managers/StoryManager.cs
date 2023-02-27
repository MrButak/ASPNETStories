using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stories.Accessors;
using Stories.Models;

namespace Stories.Managers
{
    public class StoryManager
    {
        public async Task<List<StoriesTable>> GetAllStories(Stories.Data.StoriesContext _context)
        {
            List<StoriesTable> stories = await _context.StoriesTable
                .Include(s => s.ParagraphsTable)
                .ToListAsync();
            return stories;
        }
        public static bool CreateStory(string StoryTitle, string ParagraphText, Stories.Data.StoriesContext _context)
        {
            return StoryAccessor.CreateStory(StoryTitle, ParagraphText, _context);
        }
    }
}
