using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("contact");

            builder.HasKey(x => x.Id);

            builder.Property(y => y.Id)
            .IsRequired();

            builder.Property(y => y.Description)
            .IsRequired()
            .HasMaxLength(100);

            builder.HasOne(z => z.User)
            .WithMany(z => z.Contacts)
            .HasForeignKey(z => z.IdUserFk);
            
            builder.HasOne(z => z.ContactType)
            .WithMany(z => z.Contacts)
            .HasForeignKey(z => z.IdContactTypeFk);

            builder.HasOne(z => z.ContactCategory)
            .WithMany(z => z.Contacts)
            .HasForeignKey(z => z.IdContactCategoryFk);
        }
    }
}