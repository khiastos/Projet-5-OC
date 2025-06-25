using Projet_5.Models.Entities;

public interface IModelRepository
{
    Task<Model?> GetByIdAsync(int id);

    Task<List<Model>> GetAllAsync();

    Task AddAsync(Model model);

    Task UpdateAsync(Model model);

    Task DeleteAsync(int id);
}

