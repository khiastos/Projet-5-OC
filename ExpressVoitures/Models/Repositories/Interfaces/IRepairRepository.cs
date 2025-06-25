using Projet_5.Models.Entities;

public interface IRepairRepository
{
    Task<Repair?> GetByIdAsync(int id);

    Task AddAsync(Repair repair);

    Task UpdateAsync(Repair repair);

    Task DeleteAsync(int id);
}

