using DonorApi.Models;

namespace DonorApi.DataAccess.Services
{
    public interface IDonorService
    {
        void CreateDonorAsync(Donor donor);
        void UpdateDonorAsync(Donor donor);
        void DeleteDonorAsync(int id);
        Task<Donor> GetDonorWithIdAsync(int id);
        Task<IReadOnlyList<Donor>> GetAllDonorsAsync();
    }
}
