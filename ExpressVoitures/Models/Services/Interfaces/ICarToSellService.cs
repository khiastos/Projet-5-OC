using ExpressVoitures.Models.Entities;

namespace Projet_5.Models.Services.Interfaces
{
    public interface ICarToSellService
    {
        List<CarToSells> GetAllCarToSell();
        CarToSells GetCarToSellById(int id);
        void UpdateCarToSellQuantities();
        void DeleteCarToSell(int id);
        Task<CarToSells> GetCarToSell(int id);
        Task<IList<CarToSells>> GetCarToSell();

    }
}
