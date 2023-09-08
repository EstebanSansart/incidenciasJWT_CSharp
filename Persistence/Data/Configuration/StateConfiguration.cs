using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("state");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id )
            .IsRequired();

            builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(100);
        }
    }
}