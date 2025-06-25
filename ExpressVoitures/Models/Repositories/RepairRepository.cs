using Microsoft.EntityFrameworkCore;
using Projet_5.Data;
using Projet_5.Models.Entities;

public class RepairRepository : IRepairRepository
{
    private readonly ApplicationDbContext _context;

    public RepairRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Repair?> GetByIdAsync(int id)
    {
        return await _context.Repair.FindAsync(id);
    }

    public async Task AddAsync(Repair repair)
    {
        _context.Repair.Add(repair);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Repair repair)
    {
        _context.Repair.Update(repair);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var repair = await _context.Repair.FindAsync(id);
        if (repair != null)
        {
            _context.Repair.Remove(repair);
            await _context.SaveChangesAsync();
        }
    }
}
