using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DestinationControllers : Controller
    {
        private readonly WebApplication1Context _context;

        public DestinationControllers(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: DestinationControllers
        public async Task<IActionResult> Index(string destinationDescription, string searchString)
        {
            

            // Use LINQ to get list of genres
            IQueryable<string> descQuery = from d in _context.Destination
                                           orderby d.Description
                                           select d.Description;

            // query for destination is only defined at this point
            var destination = from d in _context.Destination
                              select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                // query is delcared 
                destination = destination.Where(s => s.Location.Contains(searchString));
            }

            if(!String.IsNullOrEmpty(destinationDescription))
            {
                destination = destination.Where(x => x.Description == destinationDescription);
            }

            var destinationDescriptionVM = new LocationDescriptionViewModel();
            destinationDescriptionVM.description = new SelectList(await descQuery.Distinct().ToListAsync());
            destinationDescriptionVM.destinations = await destination.ToListAsync();

            return View(destinationDescriptionVM);
        }

        // GET: DestinationControllers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destination
                .SingleOrDefaultAsync(m => m.ID == id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // GET: DestinationControllers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DestinationControllers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Location,VisitDate,Description,ExcursionCost")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        // GET: DestinationControllers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destination.SingleOrDefaultAsync(m => m.ID == id);
            if (destination == null)
            {
                return NotFound();
            }
            return View(destination);
        }

        // POST: DestinationControllers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Location,VisitDate,Description,ExcursionCost")] Destination destination)
        {
            if (id != destination.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinationExists(destination.ID))
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
            return View(destination);
        }

        // GET: DestinationControllers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destination
                .SingleOrDefaultAsync(m => m.ID == id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // POST: DestinationControllers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destination = await _context.Destination.SingleOrDefaultAsync(m => m.ID == id);
            _context.Destination.Remove(destination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinationExists(int id)
        {
            return _context.Destination.Any(e => e.ID == id);
        }
    }
}
