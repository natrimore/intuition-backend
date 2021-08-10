﻿// <auto-generated />
using Intuition.Infrastructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Intuition.Infrastructures.Migrations.Reference
{
    [DbContext(typeof(ReferenceContext))]
    partial class ReferenceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Reference")
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("Intuition.Domains.References.AppTimeZone", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("BaseUtcOffsetHours")
                        .HasColumnType("integer");

                    b.Property<int>("BaseUtcOffsetMinutes")
                        .HasColumnType("integer");

                    b.Property<int>("BaseUtcOffsetSeconds")
                        .HasColumnType("integer");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<string>("StandartName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AppTimeZones");
                });

            modelBuilder.Entity("Intuition.Domains.References.Gender", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Intuition.Domains.References.Language", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });
#pragma warning restore 612, 618
        }
    }
}
