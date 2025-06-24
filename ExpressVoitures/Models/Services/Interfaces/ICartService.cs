using ExpressVoitures.Models.Entities;

namespace Projet_5.Models.Services.Interfaces
{
    public interface ICartService
    {
        void AddItem(Car car);
        void RemoveLine(Car car);
        void Clear();
        double GetTotalValue();

    }
}
