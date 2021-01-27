using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class UnauthorizedPersonMapping : IEntityTypeConfiguration<UnauthorizedPerson>
    {
        public void Configure(EntityTypeBuilder<UnauthorizedPerson> builder)
        {
                builder.HasKey(up => up.Id);

                builder.Property(up => up.Name)
                    .IsRequired()
                    .HasColumnType("varchar(250)");

                builder.ToTable("UnauthorizedPeople", "jacaranda");
            
        }
    }
}
