using Microsoft.EntityFrameworkCore;
using Projet_5.Data;
using Projet_5.Models.Entities;
using Projet_5.Models.Repositories.Interfaces;

public class CarImageRepository : ICarImageRepository
{
    private readonly ApplicationDbContext _context;

    public CarImageRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CarImage?> GetByIdAsync(int id)
    {
        return await _context.CarImage.FindAsync(id);
    }

    public async Task AddAsync(CarImage carImage)
    {
        _context.CarImage.Add(carImage);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CarImage carImage)
    {
        _context.CarImage.Update(carImage);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var carImage = await _context.CarImage.FindAsync(id);
        if (carImage != null)
        {
            _context.CarImage.Remove(carImage);
            await _context.SaveChangesAsync();
        }
    }
}
