using DonorApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DonorApi.DataAccess.Context
{
    public class DonorApiDb : DbContext
    {
        public DonorApiDb(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
