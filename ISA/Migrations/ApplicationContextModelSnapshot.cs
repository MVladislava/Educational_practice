﻿// <auto-generated />
using System;
using ISA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ISA.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CarsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ServicesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SparesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StaffsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CarsId");

                    b.HasIndex("ClientsId");

                    b.HasIndex("ServicesId");

                    b.HasIndex("SparesId");

                    b.HasIndex("StaffsId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Spare", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StoragesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StoragesId");

                    b.ToTable("Spares");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PostsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PostsId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Storage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Car", b =>
                {
                    b.HasOne("TestAspCSDb.Models.Domains.Client", "Client")
                        .WithMany("Cars")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Order", b =>
                {
                    b.HasOne("TestAspCSDb.Models.Domains.Car", "Cars")
                        .WithMany()
                        .HasForeignKey("CarsId");

                    b.HasOne("TestAspCSDb.Models.Domains.Client", "Clients")
                        .WithMany()
                        .HasForeignKey("ClientsId");

                    b.HasOne("TestAspCSDb.Models.Domains.Service", "Services")
                        .WithMany("Orders")
                        .HasForeignKey("ServicesId");

                    b.HasOne("TestAspCSDb.Models.Domains.Spare", "Spares")
                        .WithMany("Orders")
                        .HasForeignKey("SparesId");

                    b.HasOne("TestAspCSDb.Models.Domains.Staff", "Staffs")
                        .WithMany("Orders")
                        .HasForeignKey("StaffsId");

                    b.Navigation("Cars");

                    b.Navigation("Clients");

                    b.Navigation("Services");

                    b.Navigation("Spares");

                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Spare", b =>
                {
                    b.HasOne("TestAspCSDb.Models.Domains.Storage", "Storages")
                        .WithMany("Spares")
                        .HasForeignKey("StoragesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Storages");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Staff", b =>
                {
                    b.HasOne("TestAspCSDb.Models.Domains.Post", "Posts")
                        .WithMany("Staffs")
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Client", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Post", b =>
                {
                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Service", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Spare", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Staff", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TestAspCSDb.Models.Domains.Storage", b =>
                {
                    b.Navigation("Spares");
                });
#pragma warning restore 612, 618
        }
    }
}
