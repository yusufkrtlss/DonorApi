using DonorApi.Models;

namespace DonorApi.DataAccess.Services
{
    public interface IDonorService
    {
        Task<Donor> CreateDonorAsync(Donor donor);
        Task<Donor> UpdateDonorAsync();
        Task<Donor> DeleteDonorAsync();
        Task<Donor> GetDonorWithIdAsync(int id);
        Task<IReadOnlyList<Donor>> GetAllDonorsAsync();
    }
}
