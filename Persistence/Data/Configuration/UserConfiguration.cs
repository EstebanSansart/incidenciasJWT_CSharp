using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
  
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id )
            .IsRequired();

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.UserName)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.Email)
            .IsRequired();

            builder.Property(p => p.Password)
            .IsRequired();

            builder.Property(p => p.LastName)
            .IsRequired()
            .HasMaxLength(80);

            builder.Property(p => p.Address)
            .IsRequired()
            .HasMaxLength(80);

            builder.HasOne(p => p.DocType)
            .WithMany(p => p.Users)
            .HasForeignKey(p => p.IdDocTypeFk);

            builder.HasOne(p => p.Roles)
            .WithMany(p => p.Users)
            .HasForeignKey(p => p.IdRoleFk);
        }
    }
}