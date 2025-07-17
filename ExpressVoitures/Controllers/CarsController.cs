using Microsoft.AspNetCore.Mvc;
using ExpressVoitures.Models.Entities;
using Projet_5.Models.Utils;
using Microsoft.AspNetCore.Authorization;


namespace Projet_5.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IModelRepository _modelRepository;
        const string ImageFolder = "cars";  
        public CarsController(ICarRepository carRepository, IBrandRepository brandRepository, IModelRepository modelRepository)
        {
            _carRepository = carRepository;
            _brandRepository = brandRepository;
            _modelRepository = modelRepository;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var cars = await _carRepository.GetAllAsync();
            return View(cars);
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            return View(car);
        }

        // GET: Cars/Create
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()

        {   // Récup les marques et modèles pour le dropdown de la view
            ViewBag.Brands = await _brandRepository.GetAllAsync();
            ViewBag.Models = await _modelRepository.GetAllAsync();
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        public async Task<IActionResult> Create(Car car, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                await ImageUtils.AddAnImageAsync(car, imageFile, ImageFolder, (c, url) => c.ImageUrl = url);
                await _carRepository.AddAsync(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);

            if (car == null)
                return NotFound();

            // Récup les marques et modèles pour le dropdown de la view
            ViewBag.Brands = await _brandRepository.GetAllAsync();
            ViewBag.Models = await _modelRepository.GetAllAsync();
            return View(car);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Car car, IFormFile imageFile)
        {
            var carInDb = await _carRepository.GetByIdAsync(id);
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
            await ImageUtils.UpdateImageAsync(carInDb, imageFile, ImageFolder, c => c.ImageUrl, (c, url) => c.ImageUrl = url);

            await _carRepository.UpdateAsync(carInDb);
            return RedirectToAction(nameof(Index));
        }

        // GET: Cars/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);

            if (car is null)
                return NotFound();

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);

            if (car != null)
            {
                ImageUtils.DeleteImageAsync(car, c => c.ImageUrl);
                await _carRepository.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
