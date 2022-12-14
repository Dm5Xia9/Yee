// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Yee.Page;
using Yee.Page.Models;

#nullable disable

namespace Yee.Page.Migrations
{
    [DbContext(typeof(PageDbContext))]
    partial class PageDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("YeePage")
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Yee.Page.Models.YeeComponentValues", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<YeeCSharpLink>("ComponentRef")
                        .HasColumnType("jsonb");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<FlexOptions>("FlexOptions")
                        .HasColumnType("jsonb");

                    b.Property<bool>("IsFlexable")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsHeader")
                        .HasColumnType("boolean");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ParentId");

                    b.ToTable("YeeComponentValues", "YeePage");
                });

            modelBuilder.Entity("Yee.Page.Models.YeePage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Property")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("YeeComponentValuesId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("YeePropertyValueId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("YeeComponentValuesId");

                    b.HasIndex("YeePropertyValueId");

                    b.ToTable("YeeProperties", "YeePage");
                });

            modelBuilder.Entity("Yee.Page.Models.YeePropertyValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<bool>("IsModelData")
                        .HasColumnType("boolean");

                    b.Property<YeeCSharpLink>("PropertyType")
                        .HasColumnType("jsonb");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("YeePropertyValues", "YeePage");
                });

            modelBuilder.Entity("Yee.Page.Models.YeeRoute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LocalPath")
                        .HasColumnType("text");

                    b.Property<Guid?>("PageId")
                        .HasColumnType("uuid");

                    b.Property<string>("StaticContent")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("PageId");

                    b.ToTable("YeeRoutes", "YeePage");
                });

            modelBuilder.Entity("YeeComponentValuesYeePage", b =>
                {
                    b.Property<Guid>("PagesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("YeeComponentsId")
                        .HasColumnType("uuid");

                    b.HasKey("PagesId", "YeeComponentsId");

                    b.HasIndex("YeeComponentsId");

                    b.ToTable("YeeComponentValuesYeePage", "YeePage");
                });

            modelBuilder.Entity("Yee.Page.Models.YeeComponentValues", b =>
                {
                    b.HasOne("Yee.Page.Models.YeeComponentValues", "Parent")
                        .WithMany("Childs")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
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

            modelBuilder.Entity("Yee.Page.Models.YeeRoute", b =>
                {
                    b.HasOne("Yee.Page.Models.YeePage", "Page")
                        .WithMany()
                        .HasForeignKey("PageId");

                    b.Navigation("Page");
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
                    b.Navigation("Childs");

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
