using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Web.Data.Migrations
{
    public partial class AddedMyControlTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyControlTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultDays = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyControlTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyControlAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    MyControlTypeID = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyControlAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyControlAllocations_MyControlTypes_MyControlTypeID",
                        column: x => x.MyControlTypeID,
                        principalTable: "MyControlTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyControlAllocations_MyControlTypeID",
                table: "MyControlAllocations",
                column: "MyControlTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyControlAllocations");

            migrationBuilder.DropTable(
                name: "MyControlTypes");
        }
    }
}
