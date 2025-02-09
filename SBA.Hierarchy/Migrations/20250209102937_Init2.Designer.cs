﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SBA.Hierarchy.Common;

#nullable disable

namespace SBA.Hierarchy.Migrations
{
    [DbContext(typeof(AppDBContextProj))]
    [Migration("20250209102937_Init2")]
    partial class Init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GLOB.Domain.Entity.BG", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BGs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2041),
                            Desc = "BG 1 Desc",
                            Title = "BG 1",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2041)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2048),
                            Desc = "BG 2 Desc",
                            Title = "BG 2",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2048)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2051),
                            Desc = "BG 3 Desc",
                            Title = "BG 3",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2052)
                        });
                });

            modelBuilder.Entity("GLOB.Domain.Entity.LE", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("BGId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BGId");

                    b.ToTable("LEs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BGId = 1,
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2083),
                            Desc = "LE 1 Desc",
                            Title = "LE 1",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2083)
                        },
                        new
                        {
                            Id = 2,
                            BGId = 2,
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2089),
                            Desc = "LE 2 Desc",
                            Title = "LE 2",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2090)
                        },
                        new
                        {
                            Id = 3,
                            BGId = 3,
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2092),
                            Desc = "LE 3 Desc",
                            Title = "LE 3",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2092)
                        });
                });

            modelBuilder.Entity("GLOB.Domain.Entity.OU", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Deposit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FooterImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LEId")
                        .HasColumnType("int");

                    b.Property<string>("Law")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("WarningImg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LEId");

                    b.ToTable("OUs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "OUAddress",
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2198),
                            Deposit = "OUDeposit",
                            Desc = "OU 1 Desc",
                            FooterImg = "OUFooterImg",
                            LEId = 1,
                            Law = "OULaw",
                            LogoImg = "OULogoImg",
                            Title = "OU 1",
                            TopImg = "OUTopImg",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2199),
                            WarningImg = "OUWarningImg"
                        },
                        new
                        {
                            Id = 2,
                            Address = "OUAddress",
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2215),
                            Deposit = "OUDeposit",
                            Desc = "OU 2 Desc",
                            FooterImg = "OUFooterImg",
                            LEId = 2,
                            Law = "OULaw",
                            LogoImg = "OULogoImg",
                            Title = "OU 2",
                            TopImg = "OUTopImg",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2215),
                            WarningImg = "OUWarningImg"
                        },
                        new
                        {
                            Id = 3,
                            Address = "OUAddress",
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2220),
                            Deposit = "OUDeposit",
                            Desc = "OU 3 Desc",
                            FooterImg = "OUFooterImg",
                            LEId = 3,
                            Law = "OULaw",
                            LogoImg = "OULogoImg",
                            Title = "OU 3",
                            TopImg = "OUTopImg",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2220),
                            WarningImg = "OUWarningImg"
                        });
                });

            modelBuilder.Entity("GLOB.Domain.Entity.Org", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Orgs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1896),
                            Desc = "Org 1 Desc",
                            Title = "Org 1",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1898)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1939),
                            Desc = "Org 2 Desc",
                            Title = "Org 2",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1940)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1943),
                            Desc = "Org 3 Desc",
                            Title = "Org 3",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1943)
                        });
                });

            modelBuilder.Entity("GLOB.Domain.Entity.SU", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OUId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OUId");

                    b.ToTable("SUs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2256),
                            Desc = "SU 1 Desc",
                            OUId = 1,
                            Title = "SU 1",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2256)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2262),
                            Desc = "SU 2 Desc",
                            OUId = 2,
                            Title = "SU 2",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2262)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2265),
                            Desc = "SU 3 Desc",
                            OUId = 3,
                            Title = "SU 3",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2265)
                        });
                });

            modelBuilder.Entity("GLOB.Domain.Entity.Systemz", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrgId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrgId");

                    b.ToTable("Systemzs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1991),
                            Desc = "Systemz 1 Desc",
                            OrgId = 1,
                            Title = "Systemz 1",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1992)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2001),
                            Desc = "Systemz 2 Desc",
                            OrgId = 2,
                            Title = "Systemz 2",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2001)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2004),
                            Desc = "Systemz 3 Desc",
                            OrgId = 3,
                            Title = "Systemz 3",
                            UpdatedAt = new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2004)
                        });
                });

            modelBuilder.Entity("GLOB.Domain.Entity.TestInfra", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TestInfras");
                });

            modelBuilder.Entity("GLOB.Domain.Entity.TestProj", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TestProjs");
                });

            modelBuilder.Entity("GLOB.Domain.Entity.LE", b =>
                {
                    b.HasOne("GLOB.Domain.Entity.BG", "BG")
                        .WithMany("LEs")
                        .HasForeignKey("BGId");

                    b.Navigation("BG");
                });

            modelBuilder.Entity("GLOB.Domain.Entity.OU", b =>
                {
                    b.HasOne("GLOB.Domain.Entity.LE", "LE")
                        .WithMany("OUs")
                        .HasForeignKey("LEId");

                    b.Navigation("LE");
                });

            modelBuilder.Entity("GLOB.Domain.Entity.SU", b =>
                {
                    b.HasOne("GLOB.Domain.Entity.OU", "OU")
                        .WithMany("SUs")
                        .HasForeignKey("OUId");

                    b.Navigation("OU");
                });

            modelBuilder.Entity("GLOB.Domain.Entity.Systemz", b =>
                {
                    b.HasOne("GLOB.Domain.Entity.Org", "Org")
                        .WithMany("Systemzs")
                        .HasForeignKey("OrgId");

                    b.Navigation("Org");
                });

            modelBuilder.Entity("GLOB.Domain.Entity.BG", b =>
                {
                    b.Navigation("LEs");
                });

            modelBuilder.Entity("GLOB.Domain.Entity.LE", b =>
                {
                    b.Navigation("OUs");
                });

            modelBuilder.Entity("GLOB.Domain.Entity.OU", b =>
                {
                    b.Navigation("SUs");
                });

            modelBuilder.Entity("GLOB.Domain.Entity.Org", b =>
                {
                    b.Navigation("Systemzs");
                });
#pragma warning restore 612, 618
        }
    }
}
