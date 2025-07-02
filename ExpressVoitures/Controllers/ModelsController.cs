using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projet_5.Models.Entities;

namespace Projet_5.Controllers
{
    public class ModelsController : Controller
    {
        private readonly IModelRepository _modelRepository;

        public ModelsController(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        // GET: Models
        public async Task<IActionResult> Index()
        {
            var models = await _modelRepository.GetAllAsync();
            return View(models);
        }

        // GET: Models/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var model = await _modelRepository.GetByIdAsync(id);
            return View(model);
        }

        // GET: Models/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Models/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Name")] Model model)
        {
            if (ModelState.IsValid)
            {
                await _modelRepository.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Models/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _modelRepository.GetByIdAsync(id);
            if (model is null)
                return NotFound();

            return View(model);
        }

        // POST: Models/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Model model)
        {
            var modelInDb = await _modelRepository.GetByIdAsync(id);
            if (modelInDb is null || id != model.Id)
                return NotFound();

            modelInDb.Name = model.Name;

            await _modelRepository.UpdateAsync(modelInDb); 
            return RedirectToAction(nameof(Index));
        }


        // GET: Models/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _modelRepository.GetByIdAsync(id);

            if (model is null)
                return NotFound();

            return View(model);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _modelRepository.GetByIdAsync(id);
            if (model != null)
                await _modelRepository.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
