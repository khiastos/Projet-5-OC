using ExpressVoitures.Models.Entities;

namespace Projet_5.Models.Services.Interfaces
{
    public interface ICartService
    {
        void AddItem(CarToSells car);
        void RemoveLine(CarToSells car);
        void Clear();
        double GetTotalValue();

    }
}
