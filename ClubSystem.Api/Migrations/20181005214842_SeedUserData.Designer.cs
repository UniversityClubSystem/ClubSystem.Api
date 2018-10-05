﻿// <auto-generated />
using System;
using ClubSystem.Lib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClubSystem.Api.Migrations
{
    [DbContext(typeof(ClubSystemDbContext))]
    [Migration("20181005214842_SeedUserData")]
    partial class SeedUserData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClubSystem.Lib.Model.Club.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("UniversityName");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("ClubSystem.Lib.Model.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, CreatedDate = new DateTime(2018, 10, 6, 0, 48, 42, 22, DateTimeKind.Local), LastModifiedDate = new DateTime(2018, 10, 6, 0, 48, 42, 24, DateTimeKind.Local), Name = "Ömrüm Baki Temiz" },
                        new { Id = 2, CreatedDate = new DateTime(2018, 10, 6, 0, 48, 42, 26, DateTimeKind.Local), LastModifiedDate = new DateTime(2018, 10, 6, 0, 48, 42, 26, DateTimeKind.Local), Name = "Ömrüm Baki Temiz" }
                    );
                });

            modelBuilder.Entity("ClubSystem.Lib.Model.UserClub", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ClubId");

                    b.HasKey("UserId", "ClubId");

                    b.HasIndex("ClubId");

                    b.ToTable("UserClubs");
                });

            modelBuilder.Entity("ClubSystem.Lib.Model.UserClub", b =>
                {
                    b.HasOne("ClubSystem.Lib.Model.Club.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClubSystem.Lib.Model.User.User", "User")
                        .WithMany("UserClubs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
