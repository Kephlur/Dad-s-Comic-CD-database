using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dads_Site.Data;
using Dads_Site.Views;
using Microsoft.AspNetCore.Authorization;

namespace Dads_Site.Controllers
{
    public class CDsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CDsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CDs.ToListAsync());
        }

        public async Task<IActionResult> ShowSearchFormCDs()
        {
            return View();
        }

        // GET: CDs/Search
        public async Task<IActionResult> ShowSearchResultsCDs(String SearchPhraseName, String SearchPhraseArtist, String SearchPhraseProducer, String SearchPhraseLabel)
        {
            return View("Index", await _context.CDs.Where(j =>
            j.Name.Contains(SearchPhraseName)
            || j.Artist.Contains(SearchPhraseArtist)
            || j.Label.Contains(SearchPhraseLabel)
            || j.Producer.Contains(SearchPhraseProducer)).ToListAsync());
        }

        // GET: CDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cDs = await _context.CDs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cDs == null)
            {
                return NotFound();
            }

            return View(cDs);
        }

        [Authorize]
        // GET: CDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Artist,Producer,Label")] CDs cDs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cDs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cDs);
        }
        [Authorize]
        // GET: CDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cDs = await _context.CDs.FindAsync(id);
            if (cDs == null)
            {
                return NotFound();
            }
            return View(cDs);
        }

        // POST: CDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Artist,Producer,Label")] CDs cDs)
        {
            if (id != cDs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cDs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CDsExists(cDs.Id))
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
            return View(cDs);
        }
        [Authorize]
        // GET: CDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cDs = await _context.CDs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cDs == null)
            {
                return NotFound();
            }

            return View(cDs);
        }
        [Authorize]        // POST: CDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cDs = await _context.CDs.FindAsync(id);
            _context.CDs.Remove(cDs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CDsExists(int id)
        {
            return _context.CDs.Any(e => e.Id == id);
        }
    }
}
