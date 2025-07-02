using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpressVoitures.Models.Entities;
using Projet_5.Data;
using Projet_5.Models.Utils;
using Microsoft.AspNetCore.Authorization;


namespace Projet_5.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var cars = _context.Car
    .Include(c => c.Brand)
    .Include(c => c.Model)
    .ToList();
            return View(await _context.Car.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var car = await _context.Car
       .Include(c => c.Brand)
       .Include(c => c.Model)
       .FirstOrDefaultAsync(c => c.ID == id);

            if (id is null || car is null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.Brands = _context.Brand.ToList();
            ViewBag.Models = _context.Model.ToList();
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        public async Task<IActionResult> Create(Car car, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                await ImageUtils.AddAnImageAsync(car, imageFile, "cars", (c, url) => c.ImageUrl = url);
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
       .Include(c => c.Brand)
       .Include(c => c.Model)
       .FirstOrDefaultAsync(c => c.ID == id);

            if (car == null)
            {
                return NotFound();
            }
            ViewBag.Brands = _context.Brand.ToList();
            ViewBag.Models = _context.Model.ToList();
            return View(car);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Car car, IFormFile imageFile)
        {
            var carInDb = await _context.Car.FindAsync(id);
            if (carInDb == null || id != car.ID)
                return NotFound();

            // Mise à jour des champs hors image
            carInDb.SellingPrice = car.SellingPrice;
            carInDb.Year = car.Year;
            carInDb.IsAvailable = car.IsAvailable;
            carInDb.Finish = car.Finish;
            carInDb.BrandId = car.BrandId;
            carInDb.ModelId = car.ModelId;

            // Gestion de l'image
            await ImageUtils.UpdateImageAsync(carInDb, imageFile, "cars", c => c.ImageUrl, (c, url) => c.ImageUrl = url);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        // GET: Cars/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            var car = await _context.Car
                      .Include(c => c.Brand)
                      .Include(c => c.Model)
                      .FirstOrDefaultAsync(c => c.ID == id);

            if (id is null || car is null)
                return NotFound();

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);

            if (car != null)
            {
                ImageUtils.DeleteImageAsync(car, c => c.ImageUrl);
                _context.Car.Remove(car);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.ID == id);
        }
    }
}
