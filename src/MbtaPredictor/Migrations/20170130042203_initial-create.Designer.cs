using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MbtaPredictor.Entities;

namespace MbtaPredictor.Migrations
{
    [DbContext(typeof(MbtaDbContext))]
    [Migration("20170130042203_initial-create")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MbtaPredictor.Entities.Trip", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TripHeadSign");

                    b.Property<string>("TripName");

                    b.Property<string>("Vehicle");

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("MbtaPredictor.Entities.Vehicle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Bearing");

                    b.Property<string>("Label");

                    b.Property<string>("Lat");

                    b.Property<string>("Lon");

                    b.Property<string>("Timestamp");

                    b.Property<string>("Vehicle_Id");

                    b.HasKey("id");

                    b.ToTable("Vehicles");
                });
        }
    }
}
