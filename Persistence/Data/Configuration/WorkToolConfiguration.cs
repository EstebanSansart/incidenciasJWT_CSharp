using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class WorkToolConfiguration : IEntityTypeConfiguration<WorkTool>
    {
        public void Configure(EntityTypeBuilder<WorkTool> builder)
        {
            builder.ToTable("work_tool");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id )
            .IsRequired();

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}