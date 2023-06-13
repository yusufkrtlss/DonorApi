using DonorApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DonorApi.DataAccess.Config
{
    public class DonorConfiguration : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Fullname).IsRequired().HasMaxLength(100);
            builder.Property(x => x.BloodType).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.PhoneNo).IsRequired().HasMaxLength(13);
            builder.Property(x => x.PhotoUrl).IsRequired();
            builder.Property(x => x.Town).IsRequired();
            
        }
    }
}
