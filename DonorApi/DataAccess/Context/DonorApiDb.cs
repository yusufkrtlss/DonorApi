﻿using DonorApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DonorApi.DataAccess.Context
{
    public class DonorApiDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=104.155.56.27;Database=donorapidb;Uid=donorsystemserver;Pwd=Donor1234;TrustServerCertificate=True;");
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
