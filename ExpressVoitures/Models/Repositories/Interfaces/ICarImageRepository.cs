using ExpressVoitures.Models.Entities;
using Projet_5.Models.Entities;

namespace Projet_5.Models.Repositories.Interfaces
{
    public interface ICarImageRepository
    {
        Task<CarImage?> GetByIdAsync(int id);

        Task AddAsync(CarImage carImage);

        Task UpdateAsync(CarImage carImage);

        Task DeleteAsync(int id);
    }
}
