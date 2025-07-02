using ExpressVoitures.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Projet_5.Data;

public class CarRepository : ICarRepository
{
    private readonly ApplicationDbContext _context;

    public CarRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        return await _context.Car
            .Include(c => c.Brand)
            .Include(c => c.Model)
            .ToListAsync();
    }
    public async Task<Car?> GetByIdAsync(int id)
    {
        return await _context.Car
            .Include(c => c.Brand)
            .Include(c => c.Model)
            .FirstOrDefaultAsync(c => c.ID == id); ;
    }

    public async Task AddAsync(Car car)
    {
        _context.Car.Add(car);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Car car)
    {
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var car = await _context.Car.FindAsync(id);
        if (car != null)
        {
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
        }
    }

}
