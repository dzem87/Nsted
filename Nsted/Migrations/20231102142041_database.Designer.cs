﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nsted.Models;

#nullable disable

namespace Nsted.Migrations
{
    [DbContext(typeof(NstedDbContext))]
    [Migration("20231102142041_database")]
    partial class Database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Nsted.Models.Kunde", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adresse")
                        .HasColumnType("longtext");

                    b.Property<string>("Epost")
                        .HasColumnType("longtext");

                    b.Property<string>("Etternavn")
                        .HasColumnType("longtext");

                    b.Property<string>("Fornavn")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefon")
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
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Servicer");
                });
#pragma warning restore 612, 618
        }
    }
}
