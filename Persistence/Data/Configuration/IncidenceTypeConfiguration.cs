using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class IncidenceTypeConfiguration : IEntityTypeConfiguration<IncidenceType>
    {
        public void Configure(EntityTypeBuilder<IncidenceType> builder)
        {
            builder.ToTable("incidence_type");

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