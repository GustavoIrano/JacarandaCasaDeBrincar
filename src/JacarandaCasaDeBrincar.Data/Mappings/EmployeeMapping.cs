using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
               .IsRequired()
               .HasColumnType("varchar(250)");

            builder.Property(e => e.Cpf)
             .IsRequired(false)
             .HasColumnType("varchar(14)");

            builder.Property(e => e.Rg)
                .IsRequired(false)
                .HasColumnType("varchar(12)");

            builder.Property(e => e.Function)
                .IsRequired(false)
                .HasColumnType("varchar(100)");

            builder.ToTable("Employees", "jacaranda");
        }
    }
}
