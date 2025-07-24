using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projet_5.Models.Entities;

namespace Projet_5.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandRepository _brandRepository;

        public BrandsController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        // GET: Brands
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var brands = await _brandRepository.GetAllAsync();
            if (brands is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(brands);
        }

        // GET: Brands/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);

            if (brand is null)
                return RedirectToAction("Error", "Home");

            return View(brand);
        }

        // GET: Brands/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                await _brandRepository.AddAsync(brand);
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: Brands/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand is null)
                return RedirectToAction("Error", "Home");

            return View(brand);
        }

        // POST: Brands/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Brand brand)
        {
            var brandInDb = await _brandRepository.GetByIdAsync(id);
            if (brandInDb is null || id != brand.Id)
                return RedirectToAction("Error", "Home");

            brandInDb.Name = brand.Name;

            await _brandRepository.UpdateAsync(brandInDb);
            return RedirectToAction("Index");
        }


        // GET: Brands/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);

            if (brand is null)
                return RedirectToAction("Error", "Home");

            return View(brand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand != null)
                await _brandRepository.DeleteAsync(id);
            else
                return RedirectToAction("Error", "Home");

            return RedirectToAction("Index");

        }
    }
}
