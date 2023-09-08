using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class IncidenceDetailConfiguration : IEntityTypeConfiguration<IncidenceDetail>
    {
        public void Configure(EntityTypeBuilder<IncidenceDetail> builder)
        {
            builder.ToTable("incidence_detail");

            builder.HasKey(p => p.Id);

            builder.Property(i => i.Id )
            .IsRequired();

            builder.Property(i => i.Description)
            .IsRequired()
            .HasMaxLength(100);
            
            builder.HasOne(i => i.WorkTool)
            .WithMany(i => i.IncidenceDetails)
            .HasForeignKey(i => i.IdWorkToolFk);

            builder.HasOne(i => i.IncidenceType)
            .WithMany(i => i.IncidenceDetails)
            .HasForeignKey(i => i.IdIncidenceTypeFk);

            builder.HasOne(i => i.IncidenceLevel)
            .WithMany(i => i.IncidenceDetails)
            .HasForeignKey(i => i.IdIncidenceLevelFk);

            builder.HasOne(i => i.State)
            .WithMany(i => i.IncidenceDetails)
            .HasForeignKey(i => i.IdStateFk);
        }
    }
}