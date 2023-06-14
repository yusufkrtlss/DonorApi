using DonorApi.DataAccess.Context;
using DonorApi.Models;

namespace DonorApi.DataAccess.Services
{
    public class DonorManager : IDonorService
    {
        public void CreateDonorAsync(Donor donor)
        {
            var c = new DonorApiDb();
            c.Donors.Add(donor);
            c.SaveChanges();
        }

        public Task<Donor> DeleteDonorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Donor>> GetAllDonorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Donor> GetDonorWithIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Donor> UpdateDonorAsync(Donor donor)
        {
            throw new NotImplementedException();
        }
    }
}
