using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MbtaPredictor.Entities;

namespace MbtaPredictor.Migrations
{
    [DbContext(typeof(MbtaDbContext))]
    [Migration("20170131204136_initial-create")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MbtaPredictor.Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Trip_HeadSign");

                    b.Property<int>("Trip_Id");

                    b.Property<string>("Trip_Name");

                    b.Property<string>("Vehicle_Bearing");

                    b.Property<string>("Vehicle_Id");

                    b.Property<string>("Vehicle_Label");

                    b.Property<string>("Vehicle_Lat");

                    b.Property<string>("Vehicle_Lon");

                    b.Property<string>("Vehicle_Timestamp");

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });
        }
    }
}
