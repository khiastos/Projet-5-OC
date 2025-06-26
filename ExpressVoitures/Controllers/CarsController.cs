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
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create([Bind("SellingPrice,Year,Finish,BrandId,ModelId")] Car car)
        {
            if (ModelState.IsValid)
            {
                car.brand = await _context.Brand.FindAsync(car.BrandId);
                car.model = await _context.Model.FindAsync(car.ModelId);

                //if (carImageFile != null && carImageFile.Length > 0)
                //{
                //    using var ms = new MemoryStream();
                //    await carImageFile.CopyToAsync(ms);
                //    var imageBytes = ms.ToArray();

                //    car.CarImage = new CarImage { ImageData = imageBytes };
                //}

                _context.Car.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Brands = _context.Brand.ToList();
            ViewBag.Models = _context.Model.ToList();
            return View(car);
        }
        //public IActionResult GetImage(int id)
        //{
        //    var car = _context.Car
        //        .Include(c => c.CarImage)
        //        .FirstOrDefault(c => c.ID == id);

        //    if (car?.CarImage?.ImageData == null)
        //        return NotFound();

        //    return File(car.CarImage.ImageData, car.CarImage.ContentType ?? "image/jpeg");
        //}

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
        public async Task<IActionResult> Edit(int id, [Bind("ID,SellingPrice,Year,Finish,BrandId,ModelId,IsAvailable")] Car car)
        {
            if (id != car.ID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Car.Any(e => e.ID == car.ID))
                        return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Brands = _context.Brand.ToList();
            ViewBag.Models = _context.Model.ToList();
            return View(car);
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
