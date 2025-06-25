using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_5.Data;
using Projet_5.Models.Entities;

namespace Projet_5.Controllers
{
    public class CarImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarImage.ToListAsync());
        }

        // GET: CarImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carImage = await _context.CarImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carImage == null)
            {
                return NotFound();
            }

            return View(carImage);
        }

        // GET: CarImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarImages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Url,Description")] CarImage carImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carImage);
        }

        // GET: CarImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carImage = await _context.CarImage.FindAsync(id);
            if (carImage == null)
            {
                return NotFound();
            }
            return View(carImage);
        }

        // POST: CarImages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Url,Description")] CarImage carImage)
        {
            if (id != carImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarImageExists(carImage.Id))
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
            return View(carImage);
        }

        // GET: CarImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carImage = await _context.CarImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carImage == null)
            {
                return NotFound();
            }

            return View(carImage);
        }

        // POST: CarImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carImage = await _context.CarImage.FindAsync(id);
            if (carImage != null)
            {
                _context.CarImage.Remove(carImage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarImageExists(int id)
        {
            return _context.CarImage.Any(e => e.Id == id);
        }
    }
}
