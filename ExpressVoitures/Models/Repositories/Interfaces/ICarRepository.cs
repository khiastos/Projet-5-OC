using ExpressVoitures.Models.Entities;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetAllAsync();
    Task<Car?> GetByIdAsync(int id);
    Task AddAsync(Car car);
    Task UpdateAsync(Car car);
    Task DeleteAsync(int id);
}
