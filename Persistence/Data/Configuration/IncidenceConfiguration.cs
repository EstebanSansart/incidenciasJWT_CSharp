using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class IncidenceConfiguration : IEntityTypeConfiguration<Incidence>
    {
        public void Configure(EntityTypeBuilder<Incidence> builder)
        {
            builder.ToTable("incidence");

            builder.HasKey(x => x.Id);

            builder.Property(y => y.Id)
            .IsRequired();

            builder.Property(y => y.Description)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(y => y.Date)
            .IsRequired();

            builder.HasOne(z => z.State)
            .WithMany(z => z.Incidences)
            .HasForeignKey(z => z.IdStateFk);

            builder.HasOne(z => z.User)
            .WithMany(z => z.Incidences)
            .HasForeignKey(z => z.IdUserFk);

            builder.HasOne(z => z.Area)
            .WithMany(z => z.Incidences)
            .HasForeignKey(z => z.IdAreaFk);

            builder.HasOne(z => z.Place)
            .WithMany(z => z.Incidences)
            .HasForeignKey(z => z.IdPlaceFk);
        }
    }
}