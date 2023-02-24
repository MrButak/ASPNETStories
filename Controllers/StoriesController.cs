using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stories.Data;
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

        // GET: Stories
        /*public async Task<IActionResult> Index()
        {
              return _context.StoriesTable != null ? 
                          View(await _context.StoriesTable.ToListAsync()) :
                          Problem("Entity set 'StoriesContext.StoriesTable'  is null.");
        }*/

        // GET: Stories/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Stories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                /*_context.Add(storiesTable);
                await _context.SaveChangesAsync();*/
                Console.WriteLine("ModelState is NOT valid");
                return RedirectToAction("Create", "Stories");
            }

            Console.WriteLine("Valid Model State");
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var story = new StoriesTable { StoryTitle = model.StoryTitle };
                    _context.Add(story);
                    _context.SaveChanges();

                    var paragraph = new ParagraphsTable
                    {
                        ParagraphText = model.ParagraphText,
                        StoryId = story.StoryId
                    };
                    _context.Add(paragraph);
                    // SaveChanges() Here is causing a foreign key constraint error
                    /*_context.SaveChanges();*/

                    transaction.Commit();

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        // GET: Stories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StoriesTable == null)
            {
                return NotFound();
            }

            var storiesTable = await _context.StoriesTable.FindAsync(id);
            if (storiesTable == null)
            {
                return NotFound();
            }
            return View(storiesTable);
        }

        // POST: Stories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoryId,StoryTitle,StoryBody,StoryCreatedAt,StoryUpdatedAt")] StoriesTable storiesTable)
        {
            if (id != storiesTable.StoryId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(storiesTable);
            }

            try
            {
                _context.Update(storiesTable);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoriesTableExists(storiesTable.StoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
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

        private bool StoriesTableExists(int id)
        {
          return (_context.StoriesTable?.Any(e => e.StoryId == id)).GetValueOrDefault();
        }
    }
}
