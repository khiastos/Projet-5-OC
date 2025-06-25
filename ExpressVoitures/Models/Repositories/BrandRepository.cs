using Microsoft.EntityFrameworkCore;
using Projet_5.Data;
using Projet_5.Models.Entities;

public class BrandRepository : IBrandRepository
{
    private readonly ApplicationDbContext _context;

    public BrandRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Brand?> GetByIdAsync(int id)
    {
        return await _context.Brand.FindAsync(id);
    }

    public async Task<List<Brand>> GetAllAsync()
    {
        return await _context.Brand.ToListAsync();
    }

    public async Task AddAsync(Brand brand)
    {
        _context.Brand.Add(brand);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Brand brand)
    {
        _context.Brand.Update(brand);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var brand = await _context.Brand.FindAsync(id);
        if (brand != null)
        {
            _context.Brand.Remove(brand);
            await _context.SaveChangesAsync();
        }
    }
}
