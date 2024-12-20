﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WealthManagementAdvisory.DataLayer;

namespace WealthManagementAdvisory.DataLayer.Migrations
{
    [DbContext(typeof(WealthManagementDbContext))]
    partial class WealthManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WealthManagementAdvisory.Entities.Advisory", b =>
                {
                    b.Property<int>("AdvisoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AdvisoryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RecommendationDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecommendationTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RiskLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AdvisoryId");

                    b.ToTable("Advisories");
                });

            modelBuilder.Entity("WealthManagementAdvisory.Entities.Investment", b =>
                {
                    b.Property<int>("InvestmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("InvestmentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("InvestmentId");

                    b.ToTable("Investments");
                });

            modelBuilder.Entity("WealthManagementAdvisory.Entities.Portfolio", b =>
                {
                    b.Property<int>("PortfolioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssetAllocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PortfolioPerformance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalInvestmentValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PortfolioId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("WealthManagementAdvisory.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FinancialGoals")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RiskAppetite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
