using Projet_5.Models.Entities;

public interface IModelRepository
{
    Task<IEnumerable<Model>> GetAllAsync();
    Task<Model?> GetByIdAsync(int id);
    Task AddAsync(Model model);
    Task UpdateAsync(Model model);
    Task DeleteAsync(int id);
}

