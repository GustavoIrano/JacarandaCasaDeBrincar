using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class ContactTypeMapping : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> builder)
        {
            builder.HasKey(ct => ct.Id);

            builder.Property(ct => ct.Name)
               .IsRequired()
               .HasColumnType("varchar(250)");

            builder.ToTable("ContactTypes", "jacaranda");
        }
    }
}
