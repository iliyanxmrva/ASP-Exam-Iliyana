using asp_exam_iliyana.Data;
using asp_exam_iliyana.Models;
using asp_exam_iliyana.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace asp_exam_iliyana.Services
{
    public class CakeService : ICakeService
    {
        private readonly ApplicationDbContext _db;

        public CakeService(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<bool> AddCakeAsync(Cake cake)
        {
            _db.Add(cake);
            _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddFillingAsync(CakeFilling filling)
        {
            _db.CakeFillings.Add(filling);
            await _db.SaveChangesAsync();

            return true;
        }

        public Task<List<CakeFilling>> GetAllFillingsAsync()
        {
            return _db.CakeFillings.ToListAsync();
        }

        public async Task<bool> DeleteCakeAsync(Cake cake)
        {
            _db.Remove(cake);
            _db.SaveChangesAsync();
            return true;
        }

        public Task<List<Cake>> GetAllCakesAsync()
        {
            return _db.Cakes.ToListAsync();
        }

        public Task<Cake> GetCakeByIdAsync(Guid id)
        {
            return _db.Cakes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool UpdateCake(Cake cake)
        {
            throw new NotImplementedException();
        }

        public Task<int> CakesAmmountAsync()
        {
            var cakes = _db.Cakes.CountAsync();
            return cakes;
        }
    }
}
