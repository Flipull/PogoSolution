using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PogoWebCore.Models;

namespace PogoWebCore.Controllers
{
    [Authorize(Roles = "Editorial")]
    public class LandmarkTypesController : Controller
    {
        private readonly PogoContext _context;

        public LandmarkTypesController(PogoContext context)
        {
            _context = context;
        }

        // GET: LandmarkTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LandmarkTypes.ToListAsync());
        }

        // GET: LandmarkTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landmarkType = await _context.LandmarkTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landmarkType == null)
            {
                return NotFound();
            }

            return View(landmarkType);
        }

        // GET: LandmarkTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LandmarkTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ImageFileName")] LandmarkType landmarkType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(landmarkType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(landmarkType);
        }

        // GET: LandmarkTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landmarkType = await _context.LandmarkTypes.FindAsync(id);
            if (landmarkType == null)
            {
                return NotFound();
            }
            return View(landmarkType);
        }

        // POST: LandmarkTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImageFileName")] LandmarkType landmarkType)
        {
            if (id != landmarkType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(landmarkType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LandmarkTypeExists(landmarkType.Id))
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
            return View(landmarkType);
        }

        // GET: LandmarkTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landmarkType = await _context.LandmarkTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landmarkType == null)
            {
                return NotFound();
            }

            return View(landmarkType);
        }

        // POST: LandmarkTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var landmarkType = await _context.LandmarkTypes.FindAsync(id);
            _context.LandmarkTypes.Remove(landmarkType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LandmarkTypeExists(int id)
        {
            return _context.LandmarkTypes.Any(e => e.Id == id);
        }
    }
}
