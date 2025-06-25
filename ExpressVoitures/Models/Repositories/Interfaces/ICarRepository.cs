using ExpressVoitures.Models.Entities;

public interface ICarRepository
{
    Task<Car?> GetByIdAsync(int id);

    Task<List<Car>> GetAllAsync();

    Task AddAsync(Car car);

    Task UpdateAsync(Car car);

    Task DeleteAsync(int id);

    Task<List<Car>> GetAvailableCarsAsync();

}
