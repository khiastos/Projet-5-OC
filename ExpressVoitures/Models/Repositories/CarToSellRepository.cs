using ExpressVoitures.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Projet_5.Data;

 public class CarToSellRepository : ICarToSellRepository
    {
        private readonly ApplicationDbContext _context;
        public CarToSellRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CarToSells>> GetAll()
        {
            return await _context.CarToSells.ToListAsync();
        }
        public async Task<CarToSells> GetById(int id)
        {
            return await _context.CarToSells.FindAsync(id);
        }

        public async Task Add(CarToSells car)
        {
            _context.CarToSells.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task Update (CarToSells car)
        {
            _context.CarToSells.Update(car);
            await _context.SaveChangesAsync();
        }

        public async Task Delete (int id)
        {
            var car = await _context.CarToSells.FindAsync(id);
            if (car != null)
            {
                _context.CarToSells.Remove(car);
                await _context.SaveChangesAsync();
            }
        }

        public async Task IsAvailable (int id, bool isAvailable)
        {
            var car = await _context.CarToSells.FindAsync(id);
            if (car != null)
            {
                car.IsAvailable = isAvailable;
                await _context.SaveChangesAsync();
            }
        }
    }