﻿// <auto-generated />
using System;
using Kino.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kino.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230322132540_seed data")]
    partial class seeddata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kino.Data.Models.Bilet", b =>
                {
                    b.Property<int>("IdBilet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBilet"));

                    b.Property<float>("Cena")
                        .HasColumnType("real");

                    b.Property<int>("MiejsceIdMiejsce")
                        .HasColumnType("int");

                    b.Property<string>("Ulga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZamowienieIdZamowienie")
                        .HasColumnType("int");

                    b.HasKey("IdBilet");

                    b.HasIndex("MiejsceIdMiejsce");

                    b.HasIndex("ZamowienieIdZamowienie");

                    b.ToTable("Bilety");
                });

            modelBuilder.Entity("Kino.Data.Models.Film", b =>
                {
                    b.Property<int>("IdFilm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFilm"));

                    b.Property<string>("CzasTrawania")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataPremiery")
                        .HasColumnType("datetime2");

                    b.Property<string>("DostepneWersje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gatunek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Jezyk")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kraj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Obsada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OgrWiekowe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpisDlugi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpisKrotki")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plakat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rezyseria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFilm");

                    b.ToTable("Filmy");

                    b.HasData(
                        new
                        {
                            IdFilm = 1,
                            CzasTrawania = "02:00:00",
                            DataPremiery = new DateTime(2008, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DostepneWersje = "dsfds",
                            Gatunek = "Wojenny",
                            Jezyk = "Ang",
                            Kraj = "USA",
                            Obsada = "ssdsd",
                            OgrWiekowe = "PEGI",
                            OpisDlugi = "Fdsfsdfdsfsd",
                            OpisKrotki = "fdfdfddf",
                            Plakat = "dfjsfdsfds",
                            Rezyseria = "Ktos tam",
                            Tytul = "Za linią wroga"
                        });
                });

            modelBuilder.Entity("Kino.Data.Models.Miejsce", b =>
                {
                    b.Property<int>("IdMiejsce")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMiejsce"));

                    b.Property<bool>("CzyZajete")
                        .HasColumnType("bit");

                    b.Property<int>("Rzad")
                        .HasColumnType("int");

                    b.Property<int>("SeansIdSeans")
                        .HasColumnType("int");

                    b.HasKey("IdMiejsce");

                    b.HasIndex("SeansIdSeans");

                    b.ToTable("Miejsca");
                });

            modelBuilder.Entity("Kino.Data.Models.Sala", b =>
                {
                    b.Property<int>("IdSala")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSala"));

                    b.Property<int>("IloscMiejsc")
                        .HasColumnType("int");

                    b.Property<int>("IloscRzedow")
                        .HasColumnType("int");

                    b.Property<int>("Numer")
                        .HasColumnType("int");

                    b.HasKey("IdSala");

                    b.ToTable("Sale");

                    b.HasData(
                        new
                        {
                            IdSala = 1,
                            IloscMiejsc = 30,
                            IloscRzedow = 5,
                            Numer = 1
                        },
                        new
                        {
                            IdSala = 2,
                            IloscMiejsc = 100,
                            IloscRzedow = 30,
                            Numer = 2
                        },
                        new
                        {
                            IdSala = 3,
                            IloscMiejsc = 80,
                            IloscRzedow = 28,
                            Numer = 3
                        });
                });

            modelBuilder.Entity("Kino.Data.Models.Seans", b =>
                {
                    b.Property<int>("IdSeans")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSeans"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("FilmIdFilm")
                        .HasColumnType("int");

                    b.Property<int>("SalaIdSala")
                        .HasColumnType("int");

                    b.Property<string>("WersjaJez")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSeans");

                    b.HasIndex("FilmIdFilm");

                    b.HasIndex("SalaIdSala");

                    b.ToTable("Seanse");
                });

            modelBuilder.Entity("Kino.Data.Models.Zamowienie", b =>
                {
                    b.Property<int>("IdZamowienie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdZamowienie"));

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Platnosc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeansIdSeans")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdZamowienie");

                    b.HasIndex("SeansIdSeans");

                    b.ToTable("Zamowienia");
                });

            modelBuilder.Entity("Kino.Data.Models.Bilet", b =>
                {
                    b.HasOne("Kino.Data.Models.Miejsce", "Miejsce")
                        .WithMany()
                        .HasForeignKey("MiejsceIdMiejsce")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kino.Data.Models.Zamowienie", "Zamowienie")
                        .WithMany()
                        .HasForeignKey("ZamowienieIdZamowienie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Miejsce");

                    b.Navigation("Zamowienie");
                });

            modelBuilder.Entity("Kino.Data.Models.Miejsce", b =>
                {
                    b.HasOne("Kino.Data.Models.Seans", "Seans")
                        .WithMany()
                        .HasForeignKey("SeansIdSeans")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seans");
                });

            modelBuilder.Entity("Kino.Data.Models.Seans", b =>
                {
                    b.HasOne("Kino.Data.Models.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmIdFilm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kino.Data.Models.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("SalaIdSala")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("Kino.Data.Models.Zamowienie", b =>
                {
                    b.HasOne("Kino.Data.Models.Seans", "Seans")
                        .WithMany()
                        .HasForeignKey("SeansIdSeans")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seans");
                });
#pragma warning restore 612, 618
        }
    }
}
