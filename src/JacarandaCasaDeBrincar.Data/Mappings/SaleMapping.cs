using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class SaleMapping : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.CustomerName)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(s => s.CustomerCpf)
                    .IsRequired()
                    .HasColumnType("varchar(14)");

            builder.Property(s => s.CustomerRg)
                    .IsRequired()
                    .HasColumnType("varchar(12)");

            builder.Property(s => s.ServicesProducts)
                .IsRequired()
                .HasColumnType("varchar(450)");

            builder.ToTable("Sales", "jacaranda");
        }
    }
}
