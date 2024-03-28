using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_Mock_House_Finder.Migrations
{
    /// <inheritdoc />
    public partial class AddAllTableHouseFinder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HouseID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    DistrictID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistricName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.DistrictID);
                });

            migrationBuilder.CreateTable(
                name: "LocalUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    RoomTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.RoomTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    CampusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.CampusID);
                    table.ForeignKey(
                        name: "FK_Campus_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID");
                });

            migrationBuilder.CreateTable(
                name: "Commune",
                columns: table => new
                {
                    CommuneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommuneName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DistrictID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commune", x => x.CommuneID);
                    table.ForeignKey(
                        name: "FK_Commune_District_DistrictID",
                        column: x => x.DistrictID,
                        principalTable: "District",
                        principalColumn: "DistrictID");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<int>(type: "int", nullable: true),
                    ProfileImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressID = table.Column<int>(type: "int", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID");
                    table.ForeignKey(
                        name: "FK_User_UserRole_RoleID",
                        column: x => x.RoleID,
                        principalTable: "UserRole",
                        principalColumn: "RoleID");
                    table.ForeignKey(
                        name: "FK_User_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_User_User_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Village",
                columns: table => new
                {
                    VillageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CommuneID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Village", x => x.VillageID);
                    table.ForeignKey(
                        name: "FK_Village_Commune_CommuneID",
                        column: x => x.CommuneID,
                        principalTable: "Commune",
                        principalColumn: "CommuneID");
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    HouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerPrice = table.Column<double>(type: "float", nullable: true),
                    WarerPrice = table.Column<double>(type: "float", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: true),
                    VillageID = table.Column<int>(type: "int", nullable: true),
                    LandlordID = table.Column<int>(type: "int", nullable: true),
                    CampusID = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.HouseID);
                    table.ForeignKey(
                        name: "FK_House_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID");
                    table.ForeignKey(
                        name: "FK_House_Campus_CampusID",
                        column: x => x.CampusID,
                        principalTable: "Campus",
                        principalColumn: "CampusID");
                    table.ForeignKey(
                        name: "FK_House_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_House_User_LandlordID",
                        column: x => x.LandlordID,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_House_User_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_House_Village_VillageID",
                        column: x => x.VillageID,
                        principalTable: "Village",
                        principalColumn: "VillageID");
                });

            migrationBuilder.CreateTable(
                name: "HouseImage",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseImage", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_HouseImage_House_HouseID",
                        column: x => x.HouseID,
                        principalTable: "House",
                        principalColumn: "HouseID");
                    table.ForeignKey(
                        name: "FK_HouseImage_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_HouseImage_User_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    RateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Star = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandlordReply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseID = table.Column<int>(type: "int", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.RateID);
                    table.ForeignKey(
                        name: "FK_Rate_House_HouseID",
                        column: x => x.HouseID,
                        principalTable: "House",
                        principalColumn: "HouseID");
                    table.ForeignKey(
                        name: "FK_Rate_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Rate_User_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Rate_User_StudentID",
                        column: x => x.StudentID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseID = table.Column<int>(type: "int", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ReportID);
                    table.ForeignKey(
                        name: "FK_Report_House_HouseID",
                        column: x => x.HouseID,
                        principalTable: "House",
                        principalColumn: "HouseID");
                    table.ForeignKey(
                        name: "FK_Report_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Report_User_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Report_User_StudentID",
                        column: x => x.StudentID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<int>(type: "int", nullable: true),
                    Airon = table.Column<bool>(type: "bit", nullable: true),
                    MaxAmountOfPeople = table.Column<int>(type: "int", nullable: true),
                    CurrentAmountOfPeople = table.Column<int>(type: "int", nullable: true),
                    BuildingNumber = table.Column<int>(type: "int", nullable: true),
                    FloorNumber = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    RoomTypeID = table.Column<int>(type: "int", nullable: true),
                    HouseID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK_Room_House_HouseID",
                        column: x => x.HouseID,
                        principalTable: "House",
                        principalColumn: "HouseID");
                    table.ForeignKey(
                        name: "FK_Room_RoomType_RoomTypeID",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomType",
                        principalColumn: "RoomTypeID");
                    table.ForeignKey(
                        name: "FK_Room_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "StatusID");
                    table.ForeignKey(
                        name: "FK_Room_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Room_User_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "RoomHistory",
                columns: table => new
                {
                    RoomHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomHistory", x => x.RoomHistoryID);
                    table.ForeignKey(
                        name: "FK_RoomHistory_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID");
                    table.ForeignKey(
                        name: "FK_RoomHistory_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_RoomHistory_User_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "RoomImage",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImage", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_RoomImage_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID");
                    table.ForeignKey(
                        name: "FK_RoomImage_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_RoomImage_User_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campus_AddressID",
                table: "Campus",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Commune_DistrictID",
                table: "Commune",
                column: "DistrictID");

            migrationBuilder.CreateIndex(
                name: "IX_House_AddressID",
                table: "House",
                column: "AddressID",
                unique: true,
                filter: "[AddressID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_House_CampusID",
                table: "House",
                column: "CampusID");

            migrationBuilder.CreateIndex(
                name: "IX_House_CreatedBy",
                table: "House",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_House_LandlordID",
                table: "House",
                column: "LandlordID");

            migrationBuilder.CreateIndex(
                name: "IX_House_LastModifiedBy",
                table: "House",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_House_VillageID",
                table: "House",
                column: "VillageID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseImage_CreatedBy",
                table: "HouseImage",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HouseImage_HouseID",
                table: "HouseImage",
                column: "HouseID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseImage_LastModifiedBy",
                table: "HouseImage",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_CreatedBy",
                table: "Rate",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_HouseID",
                table: "Rate",
                column: "HouseID");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_LastModifiedBy",
                table: "Rate",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_StudentID",
                table: "Rate",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Report_CreatedBy",
                table: "Report",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Report_HouseID",
                table: "Report",
                column: "HouseID");

            migrationBuilder.CreateIndex(
                name: "IX_Report_LastModifiedBy",
                table: "Report",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Report_StudentID",
                table: "Report",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_CreatedBy",
                table: "Room",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Room_HouseID",
                table: "Room",
                column: "HouseID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_LastModifiedBy",
                table: "Room",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeID",
                table: "Room",
                column: "RoomTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_StatusID",
                table: "Room",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomHistory_CreatedBy",
                table: "RoomHistory",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RoomHistory_LastModifiedBy",
                table: "RoomHistory",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RoomHistory_RoomID",
                table: "RoomHistory",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImage_CreatedBy",
                table: "RoomImage",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImage_LastModifiedBy",
                table: "RoomImage",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImage_RoomID",
                table: "RoomImage",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_User_AddressID",
                table: "User",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedBy",
                table: "User",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_User_LastModifiedBy",
                table: "User",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleID",
                table: "User",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Village_CommuneID",
                table: "Village",
                column: "CommuneID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseImage");

            migrationBuilder.DropTable(
                name: "LocalUser");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "RoomHistory");

            migrationBuilder.DropTable(
                name: "RoomImage");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "RoomType");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Campus");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Village");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Commune");

            migrationBuilder.DropTable(
                name: "District");
        }
    }
}
