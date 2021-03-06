// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SzkolenieTechniczne.Projekt.Cimena.Infrastructure;

#nullable disable

namespace SzkolenieTechniczne.Projekt.Cimena.Infrastructure.Migrations
{
    [DbContext(typeof(CinemaTicketDbContext))]
    [Migration("20220618065049_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SzkolenieTechniczne.Projekt.Domain.Entities.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeanceTime")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3f9e7587-9ac6-4ddd-9ab4-edb28b609356"),
                            Name = "Harry",
                            SeanceTime = 150,
                            Year = 2010
                        },
                        new
                        {
                            Id = new Guid("0feff996-9f16-4f7b-8db8-a9a7c4970600"),
                            Name = "Garry",
                            SeanceTime = 150,
                            Year = 2010
                        },
                        new
                        {
                            Id = new Guid("2a6ccafc-551f-4d7a-8157-de1370e23544"),
                            Name = "Lolita",
                            SeanceTime = 150,
                            Year = 2010
                        });
                });

            modelBuilder.Entity("SzkolenieTechniczne.Projekt.Domain.Entities.Seance", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Seances");

                    b.HasData(
                        new
                        {
                            Id = new Guid("06ca2b8c-9aed-4acb-8718-9a2e43ec88be"),
                            Date = new DateTime(2019, 3, 10, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            MovieId = new Guid("3f9e7587-9ac6-4ddd-9ab4-edb28b609356")
                        },
                        new
                        {
                            Id = new Guid("4001318b-9790-4c13-9016-536f0dc2592d"),
                            Date = new DateTime(2019, 3, 10, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            MovieId = new Guid("0feff996-9f16-4f7b-8db8-a9a7c4970600")
                        },
                        new
                        {
                            Id = new Guid("bbcc5941-e385-4bf3-9e87-e08fefa81ec3"),
                            Date = new DateTime(2019, 3, 10, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            MovieId = new Guid("2a6ccafc-551f-4d7a-8157-de1370e23544")
                        });
                });

            modelBuilder.Entity("SzkolenieTechniczne.Projekt.Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeopleCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchasesDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SeanceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SeanceId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("SzkolenieTechniczne.Projekt.Domain.Entities.Seance", b =>
                {
                    b.HasOne("SzkolenieTechniczne.Projekt.Domain.Entities.Movie", null)
                        .WithMany("Seances")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SzkolenieTechniczne.Projekt.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("SzkolenieTechniczne.Projekt.Domain.Entities.Seance", null)
                        .WithMany("Tickets")
                        .HasForeignKey("SeanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SzkolenieTechniczne.Projekt.Domain.Entities.Movie", b =>
                {
                    b.Navigation("Seances");
                });

            modelBuilder.Entity("SzkolenieTechniczne.Projekt.Domain.Entities.Seance", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
