﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalksAPI.Data;

#nullable disable

namespace NZWalksAPI.Migrations
{
    [DbContext(typeof(NZWalksDbContext))]
    partial class NZWalksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalksAPI.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("75972c93-1931-415c-93e2-28d8fd44d228"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("a9854fc6-3a4c-46c8-9f93-c3731979e3e0"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("7c2c8f5a-4949-4167-a7ac-d7e515f21338"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalksAPI.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("NZWalksAPI.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cfa28603-fa6c-424d-a18e-46d089eff9f0"),
                            Code = "AKL",
                            Name = "Auckland",
                            RegionImageUrl = "https://www.pexels.com/photo/the-auckland-harbour-bridge-in-new-zealand-5342976/"
                        },
                        new
                        {
                            Id = new Guid("06fa121f-c2a0-47f0-a3b0-3f8418cbc8ff"),
                            Code = "NTL",
                            Name = "Northland",
                            RegionImageUrl = "https://www.pexels.com/photo/brown-and-orange-house-with-outdoor-plants-2259917/"
                        },
                        new
                        {
                            Id = new Guid("53d814fb-a503-4bea-af1f-9f73e26188eb"),
                            Code = "BOP",
                            Name = "Bay of Plenty"
                        },
                        new
                        {
                            Id = new Guid("0637f86e-2f43-470c-86ff-678c49183661"),
                            Code = "WGN",
                            Name = "Wellington",
                            RegionImageUrl = "Photo by Ketan Kumawat from Pexels: https://www.pexels.com/photo/body-of-water-photo-724952/"
                        },
                        new
                        {
                            Id = new Guid("da317d93-cf6d-4c28-9797-a29a9cc2e7c3"),
                            Code = "NSN",
                            Name = "Nelson",
                            RegionImageUrl = "Photo by Nathan Cowley from Pexels: https://www.pexels.com/photo/photo-of-tree-on-lake-2463951/"
                        },
                        new
                        {
                            Id = new Guid("96019430-fb47-46c2-9018-ce63f843636d"),
                            Code = "STL",
                            Name = "Southland"
                        });
                });

            modelBuilder.Entity("NZWalksAPI.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NZWalksAPI.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZWalksAPI.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalksAPI.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
