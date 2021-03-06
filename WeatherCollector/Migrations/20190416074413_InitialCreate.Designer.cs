﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherCollector.Context;

namespace WeatherCollector.Migrations
{
    [DbContext(typeof(WeatherCollectorDb))]
    [Migration("20190416074413_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherCollector.Entities.Weather", b =>
                {
                    b.Property<DateTime?>("Date");

                    b.Property<TimeSpan?>("Time");

                    b.Property<double?>("AirTemperature");

                    b.Property<int?>("CloudBase");

                    b.Property<double?>("DewPoint");

                    b.Property<int?>("HorizontalVisibility");

                    b.Property<double?>("Humidity");

                    b.Property<int?>("Overcast");

                    b.Property<int?>("Pressure");

                    b.Property<string>("WeatherConditions");

                    b.Property<string>("WindDirection");

                    b.Property<int?>("WindSpeed");

                    b.HasKey("Date", "Time");

                    b.ToTable("Weathers");
                });
#pragma warning restore 612, 618
        }
    }
}
