﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("WebApi.Entities.DrugEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Dosage")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("DrugManufacturerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Packaging")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DrugManufacturerId");

                    b.ToTable("drugs");
                });

            modelBuilder.Entity("WebApi.Entities.DrugManufacturerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("drug_manufacturer");
                });

            modelBuilder.Entity("WebApi.Entities.DrugEntity", b =>
                {
                    b.HasOne("WebApi.Entities.DrugManufacturerEntity", "Manufacturer")
                        .WithMany("DrugEntities")
                        .HasForeignKey("DrugManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("WebApi.Entities.DrugManufacturerEntity", b =>
                {
                    b.Navigation("DrugEntities");
                });
#pragma warning restore 612, 618
        }
    }
}