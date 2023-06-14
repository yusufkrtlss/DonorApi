using BloodBank.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BloodBank.DataAccess.Context
{
    public class BloodApiDb:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=104.155.56.27;Database=bloodbankdb;Uid=donorsystemserver;Pwd=Donor1234;TrustServerCertificate=True;");
        }
        public DbSet<RequestBlood> BloodRequests { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
