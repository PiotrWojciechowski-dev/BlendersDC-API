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
    public class OilController : Controller
    {
        private readonly BlendersContext _context;

        public OilController(BlendersContext context)
        {
            _context = context;
        }

        // GET: Oil
        [HttpGet]
        public async Task<IActionResult> Index()
        {
              return _context.Oils != null ? 
                          View(await _context.Oils.ToListAsync()) :
                          Problem("Entity set 'BlendersContext.Oil'  is null.");
        }

        // GET: Oil/Details/5
        [HttpGet("id/{id}/")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Oils == null)
            {
                return NotFound();
            }

            var oil = await _context.Oils
                .FirstOrDefaultAsync(m => m.ID == id);
            if (oil == null)
            {
                return NotFound();
            }

            return View(oil);
        }


        // POST: Oil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OilTank1,OilTank2,OilTankInter,CreatedAt")] Oil oil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oil);
        }

        // PUT: Oil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OilTank1,OilTank2,OilTankInter,CreatedAt")] Oil oil)
        {
            if (id != oil.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OilExists(oil.ID))
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
            return View(oil);
        }

        // DELETE: Oil/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Oils == null)
            {
                return Problem("Entity set 'BlendersContext.Oil'  is null.");
            }
            var oil = await _context.Oils.FindAsync(id);
            if (oil != null)
            {
                _context.Oils.Remove(oil);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OilExists(int id)
        {
          return (_context.Oils?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
