using Microsoft.EntityFrameworkCore;
using Projet_5.Data;
using Projet_5.Models.Repositories.Interfaces;

public class CarToRepairRepository : ICarToRepairRepository
{
    private readonly ApplicationDbContext _context;

    public CarToRepairRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CarToRepair>> GetAll()
    {
        return await _context.CarToRepairs.ToListAsync();
    }

    public async Task Add(CarToRepair car)
    {
        _context.CarToRepairs.Add(car);
        await _context.SaveChangesAsync();
    }

    public async Task Update(CarToRepair car)
    {
        _context.CarToRepairs.Update(car);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var car = await _context.CarToRepairs.FindAsync(id);
        if (car != null)
        {
            _context.CarToRepairs.Remove(car);
            await _context.SaveChangesAsync();
        }
    }
}
