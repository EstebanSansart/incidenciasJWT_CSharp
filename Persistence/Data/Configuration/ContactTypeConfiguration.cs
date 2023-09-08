using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> builder)
        {
            builder.ToTable("contact_type");

            builder.HasKey(x => x.Id);

            builder.Property(y => y.Id)
            .IsRequired();

            builder.Property(y => y.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(y => y.Description)
            .IsRequired()
            .HasMaxLength(100);
        }
    }
}