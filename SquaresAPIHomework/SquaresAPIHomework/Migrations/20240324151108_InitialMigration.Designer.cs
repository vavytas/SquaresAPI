﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SquaresAPIHomework.Data;

#nullable disable

namespace SquaresAPIHomework.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240324151108_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SquaresAPIHomework.Entities.OnePoint", b =>
                {
                    b.Property<int>("PointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PointId"));

                    b.Property<double>("XProp")
                        .HasColumnType("float");

                    b.Property<double>("YProp")
                        .HasColumnType("float");

                    b.HasKey("PointId");

                    b.ToTable("Points");
                });
#pragma warning restore 612, 618
        }
    }
}
