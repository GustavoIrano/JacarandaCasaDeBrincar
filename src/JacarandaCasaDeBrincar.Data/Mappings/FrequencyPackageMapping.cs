using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class FrequencyPackageMapping : IEntityTypeConfiguration<FrequencyPackage>
    {
        public void Configure(EntityTypeBuilder<FrequencyPackage> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
               .IsRequired()
               .HasColumnType("varchar(250)");

            builder.ToTable("FrequencyPackages", "jacaranda");
        }
    }
}
