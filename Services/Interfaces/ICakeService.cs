using asp_exam_iliyana.Models;

namespace asp_exam_iliyana.Services.Interfaces
{
    public interface ICakeService
    {
        public Task<bool> AddCakeAsync(Cake cake);
        public Task<bool> AddFillingAsync(CakeFilling filling);
        public Task<List<CakeFilling>> GetAllFillingsAsync();
        public bool UpdateCake(Cake cake);
        public Task<bool> DeleteCakeAsync(Cake cake);

        public Task<Cake> GetCakeByIdAsync(Guid id);
        public Task<List<Cake>> GetAllCakesAsync();

        public Task<int> CakesAmmountAsync();
    }
}
