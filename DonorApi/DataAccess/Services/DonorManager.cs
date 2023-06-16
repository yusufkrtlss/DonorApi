using DonorApi.DataAccess.Context;
using DonorApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

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

        public void DeleteDonorAsync(int id)
        {
            var c = new DonorApiDb();
            var donor = c.Donors.Where(x => x.Id == id).First();
            c.Donors.Remove(donor);
            c.SaveChanges();
        }

        public async Task<IReadOnlyList<Donor>> GetAllDonorsAsync()
        {
            var c = new DonorApiDb();
            return c.Donors.ToList();
            
        }

        public async Task<Donor> GetDonorWithIdAsync(int id)
        {
            var c = new DonorApiDb();
            var donor = c.Donors.Where(x => x.Id == id).FirstOrDefault();
            return donor;
        }

        

        public void UpdateDonorAsync(Donor donor)
        {
            using var c = new DonorApiDb();
            c.Donors.Update(donor);
            c.SaveChanges();
            
        }
    }
}
