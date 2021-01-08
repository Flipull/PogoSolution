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
    [Authorize(Roles = "Administrator,Editorial")]
    public class LandmarksController : Controller
    {
        private readonly PogoContext _context;

        public LandmarksController(PogoContext context)
        {
            _context = context;
        }

        // GET: Landmarks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Landmarks.ToListAsync());
        }

        // GET: Landmarks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landmark = await _context.Landmarks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landmark == null)
            {
                return NotFound();
            }

            return View(landmark);
        }

        // GET: Landmarks/Create
        public IActionResult Create()
        {
            var LandmarkTypes = new List<SelectListItem>();
            var empty = new SelectListItem
            {
                Value = "-1",
                Text = "",
                Selected = true
            };
            LandmarkTypes.Add(empty);

            foreach (var lt in _context.LandmarkTypes)
            {
                var item = new SelectListItem
                {
                    Value = lt.Id.ToString(),
                    Text = lt.Name,
                    Selected = false
                    //Group
                    //Disabled
                };
                LandmarkTypes.Add(item);
            }
            ViewBag.LandmarkTypes = LandmarkTypes;
            return View();
        }

        // POST: Landmarks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeId,Name,Longitude,Lattitude")] Landmark landmark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(landmark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(landmark);
        }

        // GET: Landmarks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landmark = await _context.Landmarks.FindAsync(id);
            if (landmark == null)
            {
                return NotFound();
            }

            var LandmarkTypes = new List<SelectListItem>();
            foreach (var lt in _context.LandmarkTypes)
            {
                var item = new SelectListItem
                {
                    Value = lt.Id.ToString(),
                    Text = lt.Name,
                    Selected = (landmark.TypeId == lt.Id)
                    //Group
                    //Disabled
                };
                LandmarkTypes.Add(item);
            }
            ViewBag.LandmarkTypes = LandmarkTypes;
            return View(landmark);
        }

        // POST: Landmarks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeId,Name,Longitude,Lattitude")] Landmark landmark)
        {
            if (id != landmark.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(landmark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LandmarkExists(landmark.Id))
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
            return View(landmark);
        }

        // GET: Landmarks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landmark = await _context.Landmarks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landmark == null)
            {
                return NotFound();
            }

            return View(landmark);
        }

        // POST: Landmarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var landmark = await _context.Landmarks.FindAsync(id);
            _context.Landmarks.Remove(landmark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LandmarkExists(int id)
        {
            return _context.Landmarks.Any(e => e.Id == id);
        }
    }
}
