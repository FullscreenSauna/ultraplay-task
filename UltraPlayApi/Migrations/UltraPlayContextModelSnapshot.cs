﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UltraPlayApi.Models;

#nullable disable

namespace UltraPlayApi.Migrations
{
    [DbContext(typeof(UltraPlayContext))]
    partial class UltraPlayContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UltraPlayApi.Models.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExternalId")
                        .HasColumnType("int");

                    b.Property<bool>("IsLive")
                        .HasColumnType("bit");

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("UltraPlayApi.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ExternalId")
                        .HasColumnType("int");

                    b.Property<bool>("IsLive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("UltraPlayApi.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("ExternalId")
                        .HasColumnType("int");

                    b.Property<string>("MatchType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("UltraPlayApi.Models.Odd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BetId")
                        .HasColumnType("int");

                    b.Property<int>("ExternalId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialBetValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BetId");

                    b.ToTable("Odds");
                });

            modelBuilder.Entity("UltraPlayApi.Models.Bet", b =>
                {
                    b.HasOne("UltraPlayApi.Models.Match", null)
                        .WithMany("Bets")
                        .HasForeignKey("MatchId");
                });

            modelBuilder.Entity("UltraPlayApi.Models.Match", b =>
                {
                    b.HasOne("UltraPlayApi.Models.Event", null)
                        .WithMany("Matches")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("UltraPlayApi.Models.Odd", b =>
                {
                    b.HasOne("UltraPlayApi.Models.Bet", null)
                        .WithMany("Odds")
                        .HasForeignKey("BetId");
                });

            modelBuilder.Entity("UltraPlayApi.Models.Bet", b =>
                {
                    b.Navigation("Odds");
                });

            modelBuilder.Entity("UltraPlayApi.Models.Event", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("UltraPlayApi.Models.Match", b =>
                {
                    b.Navigation("Bets");
                });
#pragma warning restore 612, 618
        }
    }
}
