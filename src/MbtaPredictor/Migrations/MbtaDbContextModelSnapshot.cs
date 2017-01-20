using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MbtaPredictor.Entities;

namespace MbtaPredictor.Migrations
{
    [DbContext(typeof(MbtaDbContext))]
    partial class MbtaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MbtaPredictor.Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TripHeadSign");

                    b.Property<string>("TripName");

                    b.Property<string>("Trip_Id");

                    b.Property<int>("Vehicles");

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("MbtaPredictor.Entities.Vehicle", b =>
                {
                    b.Property<int>("Vehicle_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Bearing");

                    b.Property<string>("Label");

                    b.Property<string>("Lat");

                    b.Property<string>("Lon");

                    b.Property<string>("Timestamp");

                    b.HasKey("Vehicle_Id");

                    b.ToTable("Vehicles");
                });
        }
    }
}
