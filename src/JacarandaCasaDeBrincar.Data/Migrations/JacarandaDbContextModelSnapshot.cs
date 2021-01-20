﻿// <auto-generated />
using System;
using JacarandaCasaDeBrincar.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JacarandaCasaDeBrincar.Data.Migrations
{
    [DbContext(typeof(JacarandaDbContext))]
    partial class JacarandaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("GuardianStudent", b =>
                {
                    b.Property<Guid>("GuardiansId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GuardiansId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("GuardianStudent");
                });

            modelBuilder.Entity("JacarandaCasaDeBrincar.Business.Models.Guardian", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyName")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kinship")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Occupation")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("varchar(12)");

                    b.HasKey("Id");

                    b.ToTable("Guardians", "jacaranda");
                });

            modelBuilder.Entity("JacarandaCasaDeBrincar.Business.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("BloodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("GuardianStudent", b =>
                {
                    b.HasOne("JacarandaCasaDeBrincar.Business.Models.Guardian", null)
                        .WithMany()
                        .HasForeignKey("GuardiansId")
                        .IsRequired();

                    b.HasOne("JacarandaCasaDeBrincar.Business.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
