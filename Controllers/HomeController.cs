using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stories.Data;
using Stories.Models;

namespace Stories.Controllers
{
    public class HomeController : Controller
    {
        private readonly StoriesContext _context;

        public HomeController(StoriesContext context)
        {
            _context = context;
        }

        // GET: Stories
        public async Task<IActionResult> Index()
        {
            /*return _context.StoriesTable != null ?
                        View(await _context.StoriesTable.ToListAsync()) :
                        Problem("Entity set 'StoriesContext.StoriesTable'  is null.");*/
            List<StoriesTable> stories = await _context.StoriesTable.Include(s => s.ParagraphsTable).ToListAsync();
            return View(stories);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]*/
        /*public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}