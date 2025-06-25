using ExpressVoitures.Models.Entities;
using Projet_5.Models.Entities;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);

    Task<List<User>> GetAllAsync();

    Task AddAsync(User user);

    Task UpdateAsync(User user);

    Task DeleteAsync(int id);


}
