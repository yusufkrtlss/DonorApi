using DonorApi.DataAccess.Context;
using DonorApi.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IReadOnlyList<Donor>> GetAllDonorsAsync()
        {
            var c = new DonorApiDb();
            return c.Donors.ToList();
            
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
