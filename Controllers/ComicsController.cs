using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dads_Site.Data;
using Dads_Site.Models;
using Microsoft.AspNetCore.Authorization;

namespace Dads_Site.Controllers
{
    public class ComicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Comics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comic.ToListAsync());
        }

        // GET: Comics/Search
        public async Task<IActionResult> ShowSearchFormComics()
        {
            return View();
        }

        // Post: Comics/ShowSearchResults
        public async Task<IActionResult> ShowSearchResultsComics(String SearchPhraseName, String SearchPhraseArtist, String SearchPhraseIssueNum, String SearchPhraseWriter, String SearchPhrasePublisher)
        {
            return View("Index", await _context.Comic.Where(j =>
            j.Name.Contains(SearchPhraseName)
            || j.IssueNumber.Contains(SearchPhraseIssueNum)
            || j.Artist.Contains(SearchPhraseArtist)
            || j.Writer.Contains(SearchPhraseWriter)
            || j.Publisher.Contains(SearchPhrasePublisher)).ToListAsync());
        }

        // GET: Comics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comic = await _context.Comic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comic == null)
            {
                return NotFound();
            }

            return View(comic);
        }

        [Authorize]
        // GET: Comics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IssueNumber,Artist,Writer,Publisher")] Comic comic)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(comic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (comic.Name == null) { comic.Name = string.Empty; }
            if (comic.IssueNumber == null) { comic.IssueNumber = string.Empty; }
            if (comic.Artist == null) { comic.Artist = string.Empty; }
            if (comic.Writer == null) { comic.Writer = string.Empty; }
            if (comic.Publisher == null) { comic.Publisher = string.Empty; }
            return View(comic);
        }
        [Authorize]
        // GET: Comics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comic = await _context.Comic.FindAsync(id);
            if (comic == null)
            {
                return NotFound();
            }
            return View(comic);
        }

        // POST: Comics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IssueNumber,Artist,Writer,Publisher")] Comic comic)
        {
            if (id != comic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComicExists(comic.Id))
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
            return View(comic);
        }

        [Authorize]
        // GET: Comics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comic = await _context.Comic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comic == null)
            {
                return NotFound();
            }

            return View(comic);
        }

        // POST: Comics/Delete/5
        [Authorize]


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comic = await _context.Comic.FindAsync(id);
            _context.Comic.Remove(comic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComicExists(int id)
        {
            return _context.Comic.Any(e => e.Id == id);
        }
    }
}
