using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AspTravlerz.Models;

namespace AspTravlerz.Migrations
{
    [DbContext(typeof(TripDbContext))]
    partial class TripDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("AspTravlerz.Models.Faq", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<string>("Question");

                    b.HasKey("ID");

                    b.ToTable("FAQ");
                });

            modelBuilder.Entity("AspTravlerz.Models.Segment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArrivalAddress");

                    b.Property<string>("DepartureAddress");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("ReservationID");

                    b.Property<string>("ReservationLocation");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TripID");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.HasIndex("TripID");

                    b.ToTable("Segments");
                });

            modelBuilder.Entity("AspTravlerz.Models.Trip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("ID");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("AspTravlerz.Models.Segment", b =>
                {
                    b.HasOne("AspTravlerz.Models.Trip", "Trip")
                        .WithMany("Segments")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
