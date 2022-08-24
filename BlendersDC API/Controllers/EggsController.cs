using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlendersDC_API.Data;
using BlendersDC_API.Models;

namespace BlendersDC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EggsController : Controller
    {
        private readonly BlendersContext _context;

        public EggsController(BlendersContext context)
        {
            _context = context;
        }

        // GET: Eggs
        [HttpGet]
        public async Task<IActionResult> Index()
        {
              return _context.Eggs != null ? 
                          View(await _context.Eggs.ToListAsync()) :
                          Problem("Entity set 'BlendersContext.Egg'  is null.");
        }

        // GET: Eggs/Details/5
        [HttpGet("id/{id}/")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Eggs == null)
            {
                return NotFound();
            }

            var egg = await _context.Eggs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (egg == null)
            {
                return NotFound();
            }

            return View(egg);
        }

        // POST: Eggs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NormalEgg,FreeRangeEgg,EggYolk,CreatedAt")] Egg egg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(egg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(egg);
        }

        // POST: Eggs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NormalEgg,FreeRangeEgg,EggYolk,CreatedAt")] Egg egg)
        {
            if (id != egg.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(egg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EggExists(egg.ID))
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
            return View(egg);
        }

        // POST: Eggs/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Eggs == null)
            {
                return Problem("Entity set 'BlendersContext.Egg'  is null.");
            }
            var egg = await _context.Eggs.FindAsync(id);
            if (egg != null)
            {
                _context.Eggs.Remove(egg);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EggExists(int id)
        {
          return (_context.Eggs?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
