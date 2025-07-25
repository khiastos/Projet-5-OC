using Microsoft.EntityFrameworkCore;
using Projet_5.Data;
using Projet_5.Models.Entities;

public class ModelRepository : IModelRepository
{
    private readonly ApplicationDbContext _context;

    public ModelRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Model>> GetAllAsync()
    {
        return await _context.Model
            .ToListAsync();
    }
    public async Task<Model?> GetByIdAsync(int id)
    {
        return await _context.Model
            .FirstOrDefaultAsync(model => model.Id == id);
    }

    public async Task AddAsync(Model model)
    {
        _context.Model.Add(model);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Model model)
    {
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var model = await _context.Model.FindAsync(id);
        if (model != null)
        {
            _context.Model.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
