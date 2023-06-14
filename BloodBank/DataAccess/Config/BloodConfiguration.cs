using BloodBank.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace BloodBank.DataAccess.Config
{
    public class BloodConfiguration : IEntityTypeConfiguration<RequestBlood>
    {
        public void Configure(EntityTypeBuilder<RequestBlood> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Requester).IsRequired().HasMaxLength(100);
            builder.Property(x => x.BloodType).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.BloodType).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Unit).IsRequired();
            builder.Property(x => x.Town).IsRequired();

        }
    }
}
