using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MbtaPredictor.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Trip_HeadSign = table.Column<string>(nullable: true),
                    Trip_Id = table.Column<int>(nullable: false),
                    Trip_Name = table.Column<string>(nullable: true),
                    Vehicle_Bearing = table.Column<string>(nullable: true),
                    Vehicle_Id = table.Column<string>(nullable: true),
                    Vehicle_Label = table.Column<string>(nullable: true),
                    Vehicle_Lat = table.Column<string>(nullable: true),
                    Vehicle_Lon = table.Column<string>(nullable: true),
                    Vehicle_Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
