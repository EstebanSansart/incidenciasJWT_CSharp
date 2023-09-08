using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class IncidenceLevelConfiguration : IEntityTypeConfiguration<IncidenceLevel>
    {
        public void Configure(EntityTypeBuilder<IncidenceLevel> builder)
        {
            builder.ToTable("incidence_level");

            builder.HasKey(p => p.Id);

            builder.Property(i => i.Id )
            .IsRequired();

            builder.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(i => i.Description)
            .IsRequired()
            .HasMaxLength(100);
        }
    }
}