using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stories.Data;
using Stories.Managers;
using Stories.Models;
using Stories.ViewModels;

namespace Stories.Controllers
{
    public class StoriesController : Controller
    {
        private readonly StoriesContext _context;

        public StoriesController(StoriesContext context)
        {
            _context = context;
        }

        // GET: Stories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StoriesTable == null)
            {
                return NotFound();
            }

            var StoryManager = new StoryManager();
            var storyWithAllParagraphs = StoryManager.GetStory(id, _context);

            if (storyWithAllParagraphs == null)
            {
                return NotFound();
            }
            return View(storyWithAllParagraphs);
        }

        // GET: Stories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create", "Stories");
            }

            if(StoryManager.CreateStory(model.StoryTitle, model.ParagraphText, _context))
            {
                return RedirectToAction("Index", "Home");
            }
            
            // TODO: Handle fail, show error message to user / send to an Error View
            return RedirectToAction("Index", "Home");
        }


        // GET: Stories/Add/5
        public async Task<IActionResult> Add(int? id)
        {
            if (id == null || _context.StoriesTable == null)
            {
                return NotFound();
            }
            
            StoriesTable? storyWithAllParagraphs = _context.StoriesTable
                     .Include(s => s.ParagraphsTable)
                     .FirstOrDefault(s => s.StoryId == id);

            if (storyWithAllParagraphs == null)
            {
                return NotFound();
            }

            var vm = new AddToStoryViewModel
            {
                StoryWithParagraphs = storyWithAllParagraphs
            };

            return View(vm);
        }

        // POST: Stories/Add/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int id, AddToStoryViewModel model)
        {
            if(StoryManager.AddToStory(id, model.NewParagraphText, _context))
            {
                return RedirectToAction("Index", "Home");
            };
            
            // TODO: Handle falsy return
            return RedirectToAction("Index", "Home");
        }

        // GET: Stories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StoriesTable == null)
            {
                return NotFound();
            }

            var storiesTable = await _context.StoriesTable
                .FirstOrDefaultAsync(m => m.StoryId == id);
            if (storiesTable == null)
            {
                return NotFound();
            }

            return View(storiesTable);
        }

        // POST: Stories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StoriesTable == null)
            {
                return Problem("Entity set 'StoriesContext.StoriesTable'  is null.");
            }
            var storiesTable = await _context.StoriesTable.FindAsync(id);
            if (storiesTable != null)
            {
                _context.StoriesTable.Remove(storiesTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        /*private bool StoriesTableExists(int id)
        {
          return (_context.StoriesTable?.Any(e => e.StoryId == id)).GetValueOrDefault();
        }*/
    }
}
