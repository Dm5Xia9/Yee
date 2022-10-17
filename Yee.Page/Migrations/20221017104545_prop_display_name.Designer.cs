﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Yee.Page;
using Yee.Page.Models;

#nullable disable

namespace Yee.Page.Migrations
{
    [DbContext(typeof(PageDbContext))]
    [Migration("20221017104545_prop_display_name")]
    partial class prop_display_name
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("YeePage")
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Yee.Page.Models.YeeComponentValues", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<YeeCSharpLink>("ComponentRef")
                        .HasColumnType("jsonb");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsHeader")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("YeeComponentValues", "YeePage");
                });

            modelBuilder.Entity("Yee.Page.Models.YeePage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("BodyClass")
                        .HasColumnType("text");

                    b.Property<string>("BodyId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<YeeCSharpLink>("RouterLink")
                        .HasColumnType("jsonb");

                    b.Property<YeeCSharpLink>("StyleLink")
                        .HasColumnType("jsonb");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("YeePages", "YeePage");
                });

            modelBuilder.Entity("Yee.Page.Models.YeeProperty", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Property")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("YeeComponentValuesId")
                        .HasColumnType("bigint");

                    b.Property<long?>("YeePropertyValueId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("YeeComponentValuesId");

                    b.HasIndex("YeePropertyValueId");

                    b.ToTable("YeeProperties", "YeePage");
                });

            modelBuilder.Entity("Yee.Page.Models.YeePropertyValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<bool>("IsModelData")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("YeePropertyValues", "YeePage");
                });

            modelBuilder.Entity("YeeComponentValuesYeePage", b =>
                {
                    b.Property<long>("PagesId")
                        .HasColumnType("bigint");

                    b.Property<long>("YeeComponentsId")
                        .HasColumnType("bigint");

                    b.HasKey("PagesId", "YeeComponentsId");

                    b.HasIndex("YeeComponentsId");

                    b.ToTable("YeeComponentValuesYeePage", "YeePage");
                });

            modelBuilder.Entity("Yee.Page.Models.YeeProperty", b =>
                {
                    b.HasOne("Yee.Page.Models.YeeComponentValues", "YeeComponentValues")
                        .WithMany("Properties")
                        .HasForeignKey("YeeComponentValuesId");

                    b.HasOne("Yee.Page.Models.YeePropertyValue", "YeePropertyValue")
                        .WithMany("YeeProperties")
                        .HasForeignKey("YeePropertyValueId");

                    b.Navigation("YeeComponentValues");

                    b.Navigation("YeePropertyValue");
                });

            modelBuilder.Entity("YeeComponentValuesYeePage", b =>
                {
                    b.HasOne("Yee.Page.Models.YeePage", null)
                        .WithMany()
                        .HasForeignKey("PagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yee.Page.Models.YeeComponentValues", null)
                        .WithMany()
                        .HasForeignKey("YeeComponentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Yee.Page.Models.YeeComponentValues", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Yee.Page.Models.YeePropertyValue", b =>
                {
                    b.Navigation("YeeProperties");
                });
#pragma warning restore 612, 618
        }
    }
}
