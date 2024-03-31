﻿// <auto-generated />
using System;
using Demo_Mock_House_Finder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demo_Mock_House_Finder.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240331151400_updatetableUserRole")]
    partial class updatetableUserRole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressID"));

                    b.Property<string>("AddressName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GoogleMapLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HouseID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AddressID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Campus", b =>
                {
                    b.Property<int>("CampusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampusID"));

                    b.Property<int?>("AddressID")
                        .HasColumnType("int");

                    b.Property<string>("CampusName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CampusID");

                    b.HasIndex("AddressID");

                    b.ToTable("Campus");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Commune", b =>
                {
                    b.Property<int>("CommuneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommuneID"));

                    b.Property<string>("CommuneName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DistrictID")
                        .HasColumnType("int");

                    b.HasKey("CommuneID");

                    b.HasIndex("DistrictID");

                    b.ToTable("Commune");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.District", b =>
                {
                    b.Property<int>("DistrictID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DistrictID"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DistricName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DistrictID");

                    b.ToTable("District");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.House", b =>
                {
                    b.Property<int>("HouseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HouseID"));

                    b.Property<int?>("AddressID")
                        .HasColumnType("int");

                    b.Property<int?>("CampusID")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HouseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Information")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LandlordID")
                        .HasColumnType("int");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("PowerPrice")
                        .HasColumnType("float");

                    b.Property<int?>("VillageID")
                        .HasColumnType("int");

                    b.Property<double?>("WarerPrice")
                        .HasColumnType("float");

                    b.HasKey("HouseID");

                    b.HasIndex("AddressID")
                        .IsUnique()
                        .HasFilter("[AddressID] IS NOT NULL");

                    b.HasIndex("CampusID");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LandlordID");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("VillageID");

                    b.ToTable("House");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.HouseImage", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageID"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HouseID")
                        .HasColumnType("int");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ImageID");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("HouseID");

                    b.HasIndex("LastModifiedBy");

                    b.ToTable("HouseImage");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Rate", b =>
                {
                    b.Property<int>("RateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RateID"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HouseID")
                        .HasColumnType("int");

                    b.Property<string>("LandlordReply")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Star")
                        .HasColumnType("int");

                    b.Property<int?>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("RateID");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("HouseID");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("StudentID");

                    b.ToTable("Rate");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Report", b =>
                {
                    b.Property<int>("ReportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportID"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HouseID")
                        .HasColumnType("int");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReportContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ReportID");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("HouseID");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("StudentID");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomID"));

                    b.Property<bool?>("Airon")
                        .HasColumnType("bit");

                    b.Property<int?>("Area")
                        .HasColumnType("int");

                    b.Property<int?>("BuildingNumber")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CurrentAmountOfPeople")
                        .HasColumnType("int");

                    b.Property<int?>("FloorNumber")
                        .HasColumnType("int");

                    b.Property<int?>("HouseID")
                        .HasColumnType("int");

                    b.Property<string>("Information")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MaxAmountOfPeople")
                        .HasColumnType("int");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomTypeID")
                        .HasColumnType("int");

                    b.Property<int?>("StatusID")
                        .HasColumnType("int");

                    b.HasKey("RoomID");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("HouseID");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("RoomTypeID");

                    b.HasIndex("StatusID");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.RoomHistory", b =>
                {
                    b.Property<int>("RoomHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomHistoryID"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("RoomHistoryID");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("RoomID");

                    b.ToTable("RoomHistory");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.RoomImage", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageID"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("ImageID");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("RoomID");

                    b.ToTable("RoomImage");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.RoomType", b =>
                {
                    b.Property<int>("RoomTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomTypeID"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoomTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomTypeID");

                    b.ToTable("RoomType");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Status", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusID"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusID");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<int?>("Active")
                        .HasColumnType("int");

                    b.Property<int?>("AddressID")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacebookURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("AddressID");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("RoleID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.UserRole", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            CreatedDate = new DateTime(2024, 3, 31, 22, 14, 0, 300, DateTimeKind.Local).AddTicks(1163),
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleID = 2,
                            CreatedDate = new DateTime(2024, 3, 31, 22, 14, 0, 300, DateTimeKind.Local).AddTicks(1179),
                            RoleName = "Staff"
                        },
                        new
                        {
                            RoleID = 3,
                            CreatedDate = new DateTime(2024, 3, 31, 22, 14, 0, 300, DateTimeKind.Local).AddTicks(1181),
                            RoleName = "Landlord"
                        },
                        new
                        {
                            RoleID = 4,
                            CreatedDate = new DateTime(2024, 3, 31, 22, 14, 0, 300, DateTimeKind.Local).AddTicks(1182),
                            RoleName = "Student"
                        });
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Village", b =>
                {
                    b.Property<int>("VillageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VillageID"));

                    b.Property<int?>("CommuneID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VillageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VillageID");

                    b.HasIndex("CommuneID");

                    b.ToTable("Village");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Campus", b =>
                {
                    b.HasOne("Demo_Mock_House_Finder.Model.Address", "Address")
                        .WithMany("Campuses")
                        .HasForeignKey("AddressID");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Commune", b =>
                {
                    b.HasOne("Demo_Mock_House_Finder.Model.District", "District")
                        .WithMany("Communes")
                        .HasForeignKey("DistrictID");

                    b.Navigation("District");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.House", b =>
                {
                    b.HasOne("Demo_Mock_House_Finder.Model.Address", "Address")
                        .WithOne("House")
                        .HasForeignKey("Demo_Mock_House_Finder.Model.House", "AddressID");

                    b.HasOne("Demo_Mock_House_Finder.Model.Campus", "Campus")
                        .WithMany("Houses")
                        .HasForeignKey("CampusID");

                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Demo_Mock_House_Finder.Model.User", "Landlord")
                        .WithMany("HousesLandlord")
                        .HasForeignKey("LandlordID");

                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserLastModified")
                        .WithMany("HousesModified")
                        .HasForeignKey("LastModifiedBy");

                    b.HasOne("Demo_Mock_House_Finder.Model.Village", "Village")
                        .WithMany("Houses")
                        .HasForeignKey("VillageID");

                    b.Navigation("Address");

                    b.Navigation("Campus");

                    b.Navigation("Landlord");

                    b.Navigation("UserCreated");

                    b.Navigation("UserLastModified");

                    b.Navigation("Village");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.HouseImage", b =>
                {
                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Demo_Mock_House_Finder.Model.House", "House")
                        .WithMany("HouseImages")
                        .HasForeignKey("HouseID");

                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserLastModified")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy");

                    b.Navigation("House");

                    b.Navigation("UserCreated");

                    b.Navigation("UserLastModified");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Rate", b =>
                {
                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Demo_Mock_House_Finder.Model.House", "House")
                        .WithMany("Rates")
                        .HasForeignKey("HouseID");

                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserLastModified")
                        .WithMany("RatesModified")
                        .HasForeignKey("LastModifiedBy");

                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserStudent")
                        .WithMany("RatesStudent")
                        .HasForeignKey("StudentID");

                    b.Navigation("House");

                    b.Navigation("UserCreated");

                    b.Navigation("UserLastModified");

                    b.Navigation("UserStudent");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Report", b =>
                {
                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Demo_Mock_House_Finder.Model.House", "House")
                        .WithMany("Reports")
                        .HasForeignKey("HouseID");

                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserLastModified")
                        .WithMany("ReportsModified")
                        .HasForeignKey("LastModifiedBy");

                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserStudent")
                        .WithMany("ReportsStudent")
                        .HasForeignKey("StudentID");

                    b.Navigation("House");

                    b.Navigation("UserCreated");

                    b.Navigation("UserLastModified");

                    b.Navigation("UserStudent");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Room", b =>
                {
                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Demo_Mock_House_Finder.Model.House", "House")
                        .WithMany("Rooms")
                        .HasForeignKey("HouseID");

                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserLastModified")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy");

                    b.HasOne("Demo_Mock_House_Finder.Model.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeID");

                    b.HasOne("Demo_Mock_House_Finder.Model.Status", "Status")
                        .WithMany("Rooms")
                        .HasForeignKey("StatusID");

                    b.Navigation("House");

                    b.Navigation("RoomType");

                    b.Navigation("Status");

                    b.Navigation("UserCreated");

                    b.Navigation("UserLastModified");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.RoomHistory", b =>
                {
                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserLastModified")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy");

                    b.HasOne("Demo_Mock_House_Finder.Model.Room", "Room")
                        .WithMany("RoomHistories")
                        .HasForeignKey("RoomID");

                    b.Navigation("Room");

                    b.Navigation("UserCreated");

                    b.Navigation("UserLastModified");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.RoomImage", b =>
                {
                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Demo_Mock_House_Finder.Model.User", "UserLastModified")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy");

                    b.HasOne("Demo_Mock_House_Finder.Model.Room", "Room")
                        .WithMany("Roomimages")
                        .HasForeignKey("RoomID");

                    b.Navigation("Room");

                    b.Navigation("UserCreated");

                    b.Navigation("UserLastModified");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.User", b =>
                {
                    b.HasOne("Demo_Mock_House_Finder.Model.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressID");

                    b.HasOne("Demo_Mock_House_Finder.Model.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Demo_Mock_House_Finder.Model.User", "LastModifiedUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy");

                    b.HasOne("Demo_Mock_House_Finder.Model.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleID");

                    b.Navigation("Address");

                    b.Navigation("CreatedUser");

                    b.Navigation("LastModifiedUser");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Village", b =>
                {
                    b.HasOne("Demo_Mock_House_Finder.Model.Commune", "Commune")
                        .WithMany("Villages")
                        .HasForeignKey("CommuneID");

                    b.Navigation("Commune");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Address", b =>
                {
                    b.Navigation("Campuses");

                    b.Navigation("House");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Campus", b =>
                {
                    b.Navigation("Houses");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Commune", b =>
                {
                    b.Navigation("Villages");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.District", b =>
                {
                    b.Navigation("Communes");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.House", b =>
                {
                    b.Navigation("HouseImages");

                    b.Navigation("Rates");

                    b.Navigation("Reports");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Room", b =>
                {
                    b.Navigation("RoomHistories");

                    b.Navigation("Roomimages");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Status", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.User", b =>
                {
                    b.Navigation("HousesLandlord");

                    b.Navigation("HousesModified");

                    b.Navigation("RatesModified");

                    b.Navigation("RatesStudent");

                    b.Navigation("ReportsModified");

                    b.Navigation("ReportsStudent");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.UserRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Demo_Mock_House_Finder.Model.Village", b =>
                {
                    b.Navigation("Houses");
                });
#pragma warning restore 612, 618
        }
    }
}
