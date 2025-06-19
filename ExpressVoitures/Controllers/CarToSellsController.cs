using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Mvc;

public class CarToSellsController : Controller
{
    private readonly ICarToSellsRepository _repo;

    public CarToSellsController(ICarToSellsRepository repo)
    {
        _repo = repo;
    }
    public async Task<IActionResult> Index()
    {
        var cars = await _repo.GetAll();
        return View(cars);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CarToSells car)
    {
        if (ModelState.IsValid)
        {
            await _repo.Add(car);
            return RedirectToAction(nameof(Index));
        }
        return View(car);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var car = await _repo.GetById(id);
        if (car == null)
        {
            return NotFound();
        }
        return View(car);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CarToSells car)
    {
        if (ModelState.IsValid)
        {
            await _repo.Update(car);
            return RedirectToAction(nameof(Index));
        }
        return View(car);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var car = await _repo.GetById(id);
        if (car == null)
        {
            return NotFound();
        }
        return View(car);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _repo.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Details(int id)
    {
        var car = await _repo.GetById(id);
        if (car == null)
        {
            return NotFound();
        }  
        return View(car);
    }

}

