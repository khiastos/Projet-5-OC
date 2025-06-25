using Projet_5.Models.Entities;

public interface IBrandRepository
{
    Task<Brand?> GetByIdAsync(int id);

    Task<List<Brand>> GetAllAsync();

    Task AddAsync(Brand brand);

    Task UpdateAsync(Brand brand);

    Task DeleteAsync(int id);
}

