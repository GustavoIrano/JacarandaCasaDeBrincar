using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);            

            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(s => s.Cpf)
                .IsRequired(false)
                .HasColumnType("varchar(14)");

            builder.Property(s => s.Rg)
                .IsRequired(false)
                .HasColumnType("varchar(12)");

            builder.Property(s => s.BloodType)
                .IsRequired()
                .HasColumnType("varchar(3)");

            builder.Property(s => s.Gender)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(s => s.Picture)
                .IsRequired(false)
                .HasColumnType("varchar(MAX)");

            builder.ToTable("Students", "jacaranda");
        }
    }
}
