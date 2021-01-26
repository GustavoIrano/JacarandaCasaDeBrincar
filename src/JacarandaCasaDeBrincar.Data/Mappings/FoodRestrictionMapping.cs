using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class FoodRestrictionMapping : IEntityTypeConfiguration<FoodRestriction>
    {
        public void Configure(EntityTypeBuilder<FoodRestriction> builder)
        {
            builder.HasKey(fr => fr.Id);

            builder.Property(fr => fr.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.ToTable("FoodRestrictions", "jacaranda");
        }
    }
}
