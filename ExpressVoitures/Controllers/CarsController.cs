using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpressVoitures.Models.Entities;
using Projet_5.Data;
using Microsoft.AspNetCore.Authorization;
using Projet_5.Models.Entities;

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
    .Include(c => c.brand)
    .Include(c => c.model)
    .ToList();
            return View(await _context.Car.ToListAsync());
        }


        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.ID == id);
            if (car == null)
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
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Crée le dossier si nécessaire
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/cars");
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    // Crée un nom de fichier unique
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePath = Path.Combine(uploadPath, fileName);

                    // Sauvegarde le fichier
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Enregistre le chemin relatif (pour affichage dans le site)
                    car.ImageUrl = "/images/cars/" + fileName;
                }

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
       .Include(c => c.brand)
       .Include(c => c.model)
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
            if (id != car.ID)
                return NotFound();

            var carInDb = await _context.Car.FindAsync(id);
            if (carInDb == null)
                return NotFound();

            carInDb.SellingPrice = car.SellingPrice;
            carInDb.Year = car.Year;
            carInDb.IsAvailable = car.IsAvailable;
            carInDb.Finish = car.Finish;
            carInDb.BrandId = car.BrandId;
            carInDb.ModelId = car.ModelId;

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                Directory.CreateDirectory(uploads);
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                carInDb.ImageUrl = "/images/" + fileName;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        // GET: Cars/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.ID == id);
            if (car == null)
            {
                return NotFound();
            }

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
                _context.Car.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.ID == id);
        }
    }
}
