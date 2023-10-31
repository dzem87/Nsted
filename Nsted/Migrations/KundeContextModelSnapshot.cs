﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nsted.Models;

#nullable disable

namespace Nsted.Migrations
{
    [DbContext(typeof(NstedDbContext))]
    partial class KundeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Nsted.Models.Kunde", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Epost")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Etternavn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Fornavn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Kunder");
                });

            modelBuilder.Entity("Nsted.Models.OpprettService", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ServiceNotat")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Servicer");
                });
#pragma warning restore 612, 618
        }
    }
}
