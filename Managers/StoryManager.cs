﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stories.Accessors;
using Stories.Models;

namespace Stories.Managers
{
    public class StoryManager
    {
        public async Task<List<StoriesTable>> GetAllStories(Stories.Data.StoriesContext _context)
        {
            var StoryAccessor = new StoryAccessor();
            List<StoriesTable> AllStories = await StoryAccessor.QueryAllStories(_context);
            return AllStories;
        }
        public static bool CreateStory(string StoryTitle, string ParagraphText, Stories.Data.StoriesContext _context)
        {
            return StoryAccessor.CreateStory(StoryTitle, ParagraphText, _context);
        }
    }
}
