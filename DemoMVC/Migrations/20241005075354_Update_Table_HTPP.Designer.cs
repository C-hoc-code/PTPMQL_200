﻿// <auto-generated />
using DemoMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoMVC.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241005075354_Update_Table_HTPP")]
    partial class Update_Table_HTPP
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("DemoMVC.Models.Entites.HeThongPhanPhoi", b =>
                {
                    b.Property<string>("MaHTPP")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.Property<string>("TenHTPP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaHTPP");

                    b.ToTable("HeThongPhanPhoi");

                    b.HasDiscriminator().HasValue("HeThongPhanPhoi");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DemoMVC.Models.Entites.Person", b =>
                {
                    b.Property<string>("PersonID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("QueQuan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PersonID");

                    b.ToTable("Person");

                    b.HasDiscriminator().HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DemoMVC.Models.Entites.Student", b =>
                {
                    b.Property<string>("StudentID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StudentID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("DemoMVC.Models.Entites.DaiLy", b =>
                {
                    b.HasBaseType("DemoMVC.Models.Entites.HeThongPhanPhoi");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DienThoai")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaDaiLy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NguoiDaiDien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenDaiLy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("DaiLy");
                });

            modelBuilder.Entity("DemoMVC.Models.Entites.Employee", b =>
                {
                    b.HasBaseType("DemoMVC.Models.Entites.Person");

                    b.Property<string>("CongTy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
