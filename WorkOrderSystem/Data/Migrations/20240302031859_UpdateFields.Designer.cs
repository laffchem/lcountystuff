﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkOrderSystem.Data;

#nullable disable

namespace WorkOrderSystem.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240302031859_UpdateFields")]
    partial class UpdateFields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Models.Technician", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");
                });

            modelBuilder.Entity("Models.WorkOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateAssigned")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateComplete")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateReceived")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Problem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TechnicianId");

                    b.ToTable("WorkOrders");
                });

            modelBuilder.Entity("Models.WorkOrder", b =>
                {
                    b.HasOne("Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Technician");
                });
#pragma warning restore 612, 618
        }
    }
}
