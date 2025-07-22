using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projet_5.Models.Utils;


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
            if (car is null)
            {
                return RedirectToAction("Error", "Home");
            }
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
        [HttpPost]
        public async Task<IActionResult> Create(Car car, IFormFile imageFile)
        {

            /* Gestion du message d'erreur pour l'image ici car c'est ici que IFormFile est accessible, comparé à dans l'entité Car qui ne reçoit pas
             directement le fichier depuis la vue, ou alors c'est faisable en rajoutant un IFormFile dans l'entité car */

            if (imageFile == null || imageFile.Length == 0)
            {
                ModelState.AddModelError("ImageUrl", "La photo est obligatoire");
            }
            else
            {
                // Vérification de l'image, pour contrôler ce qui peut être ajouté ou non au site (protection contre les attaques/script XXS)
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
                var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("ImageUrl", "Seuls les fichiers image (jpg, jpeg, png, webp) sont autorisés.");
                }
            }

            if (ModelState.IsValid)
            {
                await ImageUtils.AddAnImageAsync(car, imageFile, ImageFolder, (c, url) => c.ImageUrl = url);
                await _carRepository.AddAsync(car);
                return RedirectToAction("CreateValidated");
            }

            ViewBag.Brands = await _brandRepository.GetAllAsync();
            ViewBag.Models = await _modelRepository.GetAllAsync();
            return View(car);
        }



        public IActionResult CreateValidated()
        {
            return View();
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
            {
                return RedirectToAction("Error", "Home");
            }

            // Mise à jour des champs hors image
            carInDb.SellingPrice = car.SellingPrice;
            carInDb.Year = car.Year;
            carInDb.IsAvailable = car.IsAvailable;
            carInDb.Finish = car.Finish;
            carInDb.BrandId = car.BrandId;
            carInDb.ModelId = car.ModelId;


            // Vérification de l'image, pour contrôler ce qui peut être ajouté ou non au site (protection contre les attaques/script XXS)
            if (imageFile != null)
            {
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
                var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("ImageUrl", "Seuls les fichiers image (jpg, jpeg, png, webp) sont autorisés.");
                    return View(car);
                }
            }

            // Update l'image si valide
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
            {
                return RedirectToAction("Error", "Home");
            }

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
                var title = $"{car.Year} {car.Brand?.Name} {car.Model?.Name}";
                TempData["DeletedCarTitle"] = title;
                ImageUtils.DeleteImageAsync(car, c => c.ImageUrl);
                await _carRepository.DeleteAsync(id);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("DeleteValidated");
        }

        public IActionResult DeleteValidated()
        {
            return View();
        }

    }
}
