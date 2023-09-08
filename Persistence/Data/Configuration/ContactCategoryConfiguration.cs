using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContactCategoryConfiguration : IEntityTypeConfiguration<ContactCategory>
    {
        public void Configure(EntityTypeBuilder<ContactCategory> builder)
        {
            builder.ToTable("contact_category");

            builder.HasKey(x => x.Id);

            builder.Property(y => y.Name)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}