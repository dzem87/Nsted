﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nsted.Data;

#nullable disable

namespace Nsted.Migrations
{
    [DbContext(typeof(NstedDbContext))]
    partial class NstedDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Nsted.Models.Service", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("KundeID")
                        .HasColumnType("longtext");

                    b.Property<string>("Notat")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Produkttype")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Serienummer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ServiceRep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Årsmodell")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Servicer");
                });

            modelBuilder.Entity("Nsted.Models.Sjekkliste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Serienummer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ServiceID")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkBremser")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkBremsesylinder")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkClutchLamellerForSlitasje")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkHydrauliskSylinder")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkKile")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkKjedestrammer")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkKnappekasse")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkLagerForTrommel")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkLedningsnett")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkPinonLager")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkRadio")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkRyngsylinder")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkSlanger")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkWire")
                        .HasColumnType("longtext");

                    b.Property<string>("SkifteOljeGirBoks")
                        .HasColumnType("longtext");

                    b.Property<string>("SkifteOljeTank")
                        .HasColumnType("longtext");

                    b.Property<string>("TestHydraulikkblokk")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Sjekklister");
                });
#pragma warning restore 612, 618
        }
    }
}
