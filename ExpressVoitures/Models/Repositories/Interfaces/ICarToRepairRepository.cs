using ExpressVoitures.Models.Entities;

namespace Projet_5.Models.Repositories.Interfaces
{
    public interface ICarToRepairRepository
    {
        Task<List<CarToRepair>> GetAll();
        Task<CarToRepair> GetById(int id);
        Task Add(CarToRepair car);
        Task Update(CarToRepair car);
        Task Delete(int id);
    }
}
