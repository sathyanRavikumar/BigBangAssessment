﻿// <auto-generated />
using System;
using HotelRoomBooking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelRoomBooking.Migrations
{
    [DbContext(typeof(ModelDbContext))]
    [Migration("20230526064239_Maindb")]
    partial class Maindb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelRoomBooking.Models.Hotels", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"));

                    b.Property<string>("HotelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelId");

                    b.ToTable("hotels");
                });

            modelBuilder.Entity("HotelRoomBooking.Models.Resevation", b =>
                {
                    b.Property<int>("reserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reserId"));

                    b.Property<string>("Cust_address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int?>("RoomsRoomId")
                        .HasColumnType("int");

                    b.Property<int>("checkIn")
                        .HasColumnType("int");

                    b.Property<int>("checkOut")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("reserId");

                    b.HasIndex("RoomsRoomId");

                    b.HasIndex("userId");

                    b.ToTable("resevations");
                });

            modelBuilder.Entity("HotelRoomBooking.Models.Rooms", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int?>("HotelsHotelId")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.HasIndex("HotelsHotelId");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("HotelRoomBooking.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<string>("emailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("HotelRoomBooking.Models.Resevation", b =>
                {
                    b.HasOne("HotelRoomBooking.Models.Rooms", null)
                        .WithMany("Resevations")
                        .HasForeignKey("RoomsRoomId");

                    b.HasOne("HotelRoomBooking.Models.User", null)
                        .WithMany("Resevations")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelRoomBooking.Models.Rooms", b =>
                {
                    b.HasOne("HotelRoomBooking.Models.Hotels", null)
                        .WithMany("rooms")
                        .HasForeignKey("HotelsHotelId");
                });

            modelBuilder.Entity("HotelRoomBooking.Models.Hotels", b =>
                {
                    b.Navigation("rooms");
                });

            modelBuilder.Entity("HotelRoomBooking.Models.Rooms", b =>
                {
                    b.Navigation("Resevations");
                });

            modelBuilder.Entity("HotelRoomBooking.Models.User", b =>
                {
                    b.Navigation("Resevations");
                });
#pragma warning restore 612, 618
        }
    }
}
