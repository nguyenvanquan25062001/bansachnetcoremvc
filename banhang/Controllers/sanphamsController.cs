using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using banhang.Data;
using banhang.Models;
using Microsoft.AspNetCore.Authorization;

namespace banhang.Controllers
{
    public class sanphamsController : Controller
    {
        private readonly banhangContext _context;

        public sanphamsController(banhangContext context)
        {
            _context = context;
        }
       

        // GET: sanphams
        public async Task<IActionResult> Index()
        {
            var banhangContext = _context.sanpham.Include(s => s.Category);
            return View(await banhangContext.ToListAsync());
        }
        [HttpPost]
		public async Task<IActionResult> Index(int catid , string keyworks)
		{
			var banhangContext = _context.sanpham.Include(s => s.Category).Where(s => s.Name.Contains(keyworks) && s.CategoryId == catid);
			return View(await banhangContext.ToListAsync());
		}
        [HttpGet]
        public async Task<IActionResult> danhsachsanpham()
        {
            var danhsachsanpham = await _context.sanpham.ToListAsync();
            return View(danhsachsanpham);
        }

		// GET: sanphams/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sanpham == null)
            {
                return NotFound();
            }

            var sanpham = await _context.sanpham
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: sanphams/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name");
            return View();
        }

        // POST: sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,ImageUrl,Quantity,CategoryId")] sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(danhsachsanpham));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", sanpham.CategoryId);
            return View(sanpham);
        }

        // GET: sanphams/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sanpham == null)
            {
                return NotFound();
            }

            var sanpham = await _context.sanpham.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id", sanpham.CategoryId);
            return View(sanpham);
        }

        // POST: sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,ImageUrl,Quantity,CategoryId")] sanpham sanpham)
        {
            if (id != sanpham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sanphamExists(sanpham.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(danhsachsanpham));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id", sanpham.CategoryId);
            return View(sanpham);
        }

        // GET: sanphams/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sanpham == null)
            {
                return NotFound();
            }

            var sanpham = await _context.sanpham
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sanpham == null)
            {
                return Problem("Entity set 'banhangContext.sanpham'  is null.");
            }
            var sanpham = await _context.sanpham.FindAsync(id);
            if (sanpham != null)
            {
                _context.sanpham.Remove(sanpham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(danhsachsanpham));
        }

        private bool sanphamExists(int id)
        {
          return (_context.sanpham?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
