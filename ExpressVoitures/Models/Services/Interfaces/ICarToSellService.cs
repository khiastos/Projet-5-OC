using ExpressVoitures.Models.Entities;

namespace Projet_5.Models.Services.Interfaces
{
    public interface ICarToSellService
    {
        List<Car> GetAllCarToSell();
        Car GetCarToSellById(int id);
        void UpdateCarToSellQuantities();
        void DeleteCarToSell(int id);
        Task<Car> GetCarToSell(int id);
        Task<IList<Car>> GetCarToSell();

    }
}
