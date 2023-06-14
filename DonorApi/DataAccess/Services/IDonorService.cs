using DonorApi.Models;

namespace DonorApi.DataAccess.Services
{
    public interface IDonorService
    {
        void CreateDonorAsync(Donor donor);
        Task<Donor> UpdateDonorAsync(Donor donor);
        Task<Donor> DeleteDonorAsync(int id);
        Task<Donor> GetDonorWithIdAsync(int id);
        Task<IReadOnlyList<Donor>> GetAllDonorsAsync();
    }
}
