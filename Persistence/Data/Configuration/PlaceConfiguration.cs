using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable("place");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id )
            .IsRequired();

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(100);

            builder.HasOne(p => p.Area)
            .WithMany(p => p.Places)
            .HasForeignKey(p => p.IdAreaFk);
        }
    }
}