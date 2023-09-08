using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DocTypeConfiguration : IEntityTypeConfiguration<DocType>
    {
        public void Configure(EntityTypeBuilder<DocType> builder)
        {
            builder.ToTable("doc_type");

            builder.HasKey(x => x.Id);

            builder.Property(y => y.Id)
            .IsRequired();

            builder.Property(y => y.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(y => y.Abbreviation)
            .IsRequired()
            .HasMaxLength(10);
        }
    }
}