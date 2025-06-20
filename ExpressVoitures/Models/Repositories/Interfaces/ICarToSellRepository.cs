using ExpressVoitures.Models.Entities;

public interface ICarToSellRepository
{
    Task<List<CarToSells>> GetAll();
    Task<CarToSells> GetById(int id);
    Task Add (CarToSells car);
    Task Update(CarToSells car);
    Task Delete(int id);
    Task IsAvailable(int id, bool isAvailable);
}
