using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class ContactMapping : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.PhoneOne)
                 .IsRequired()
                 .HasColumnType("varchar(14)");

            builder.Property(c => c.PhoneTwo)
                 .IsRequired(false)
                 .HasColumnType("varchar(14)");

            builder.ToTable("Contacts", "jacaranda");
        }
    }
}
