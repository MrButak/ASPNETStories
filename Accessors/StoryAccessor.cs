using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stories.Data;
using Stories.Models;
using System.Collections.Generic;

namespace Stories.Accessors
{
    public class StoryAccessor
    {
        public async Task<List<StoriesTable>> QueryAllStories(Stories.Data.StoriesContext _context)
        {
            List<StoriesTable> stories = await _context.StoriesTable
                .Include(s => s.ParagraphsTable)
                .ToListAsync();
            return stories;
        }

        public StoriesTable QueryStory(int? id, Stories.Data.StoriesContext _context)
        {
            var storyWithAllParagraphs = _context.StoriesTable
                .Include(s => s.ParagraphsTable)
                .FirstOrDefault(s => s.StoryId == id);
            return storyWithAllParagraphs;
        }

        public static bool InsertNewStory(string StoryTitle, string ParagraphText, Stories.Data.StoriesContext _context)
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

        public static bool InsertParagraphIntoStory(int id, string ParagraphText, Stories.Data.StoriesContext _context)
        {
           try
            {
                var newParagraph = new ParagraphsTable
                {
                    StoryId = id,
                    ParagraphText = ParagraphText
                };
                _context.ParagraphsTable.Add(newParagraph);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public static bool DeleteStory(int id, Stories.Data.StoriesContext _context)
        {
            var storyIdentifiedById = _context.StoriesTable.Find(id);
            if (storyIdentifiedById != null)
            {
                _context.StoriesTable.Remove(storyIdentifiedById);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
