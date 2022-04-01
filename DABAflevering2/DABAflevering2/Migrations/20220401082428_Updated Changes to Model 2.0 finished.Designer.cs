﻿// <auto-generated />
using System;
using DABAflevering2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DABAflevering2.Migrations
{
    [DbContext(typeof(au674304Context))]
    [Migration("20220401082428_Updated Changes to Model 2.0 finished")]
    partial class UpdatedChangestoModel20finished
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DABAflevering2.Bookingoverview", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("RoomID");

                    b.Property<TimeSpan>("BookingStart")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("BookingEnd")
                        .HasColumnType("time");

                    b.Property<int>("Cvr")
                        .HasColumnType("int")
                        .HasColumnName("CVR");

                    b.HasKey("RoomId", "BookingStart", "BookingEnd")
                        .HasName("PK__Bookingo__93FCB6C609F9E8D2");

                    b.HasIndex("Cvr");

                    b.ToTable("Bookingoverview", (string)null);
                });

            modelBuilder.Entity("DABAflevering2.Chairman", b =>
                {
                    b.Property<int>("Cpr")
                        .HasColumnType("int")
                        .HasColumnName("CPR");

                    b.Property<string>("ChairmanName")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.Property<int>("Cvr")
                        .HasColumnType("int")
                        .HasColumnName("CVR");

                    b.Property<string>("HomeAddress")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.HasKey("Cpr")
                        .HasName("PK__Chairman__C1F8973CD4538063");

                    b.HasIndex("Cvr");

                    b.HasIndex(new[] { "Cpr" }, "UQ__Chairman__C1F8973DC623382E")
                        .IsUnique();

                    b.ToTable("Chairman", (string)null);
                });

            modelBuilder.Entity("DABAflevering2.Member", b =>
                {
                    b.Property<int>("Cpr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cpr"), 1L, 1);

                    b.Property<int>("CvrNavigationCvr")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cpr");

                    b.HasIndex("CvrNavigationCvr");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("DABAflevering2.Municipality", b =>
                {
                    b.Property<int>("MunicipalityId")
                        .HasColumnType("int")
                        .HasColumnName("MunicipalityID");

                    b.HasKey("MunicipalityId");

                    b.HasIndex(new[] { "MunicipalityId" }, "UQ__Municipa__009B60F4FC02DE25")
                        .IsUnique();

                    b.ToTable("Municipality", (string)null);
                });

            modelBuilder.Entity("DABAflevering2.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .HasColumnType("int")
                        .HasColumnName("propertyID");

                    b.Property<bool?>("Coffee")
                        .HasColumnType("bit")
                        .HasColumnName("coffee");

                    b.Property<int>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("RoomID");

                    b.Property<bool?>("SoccerGoals")
                        .HasColumnType("bit")
                        .HasColumnName("soccerGoals");

                    b.Property<bool?>("Whiteboard")
                        .HasColumnType("bit")
                        .HasColumnName("whiteboard");

                    b.Property<bool?>("WiFi")
                        .HasColumnType("bit");

                    b.HasKey("PropertyId");

                    b.HasIndex(new[] { "RoomId" }, "UQ__properti__328639182028850B")
                        .IsUnique();

                    b.HasIndex(new[] { "PropertyId" }, "UQ__properti__9C0B8C5CE91EE6F5")
                        .IsUnique();

                    b.ToTable("properties", (string)null);
                });

            modelBuilder.Entity("DABAflevering2.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("RoomID");

                    b.Property<int?>("AccessCode")
                        .HasColumnType("int");

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("int")
                        .HasColumnName("MunicipalityID");

                    b.Property<string>("RoomAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Roomlimit")
                        .HasColumnType("int")
                        .HasColumnName("roomlimit");

                    b.Property<TimeSpan?>("TimespanEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("TimespanStart")
                        .HasColumnType("time");

                    b.HasKey("RoomId");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex(new[] { "RoomId" }, "UQ__rooms__32863918C12586CE")
                        .IsUnique();

                    b.ToTable("rooms", (string)null);
                });

            modelBuilder.Entity("DABAflevering2.Society", b =>
                {
                    b.Property<int>("Cvr")
                        .HasColumnType("int")
                        .HasColumnName("CVR");

                    b.Property<string>("Activity")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("int")
                        .HasColumnName("MunicipalityID");

                    b.Property<int?>("NumberOfMembers")
                        .HasColumnType("int");

                    b.HasKey("Cvr")
                        .HasName("PK__Societie__C1FE224CA7F4BA4B");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex(new[] { "Cvr" }, "UQ__Societie__C1FE224D644D06EE")
                        .IsUnique();

                    b.ToTable("Societies");
                });

            modelBuilder.Entity("DABAflevering2.Bookingoverview", b =>
                {
                    b.HasOne("DABAflevering2.Society", "CvrNavigation")
                        .WithMany("Bookingoverviews")
                        .HasForeignKey("Cvr")
                        .IsRequired()
                        .HasConstraintName("FK__Bookingover__CVR__5ECA0095");

                    b.HasOne("DABAflevering2.Room", "Room")
                        .WithMany("Bookingoverviews")
                        .HasForeignKey("RoomId")
                        .IsRequired()
                        .HasConstraintName("FK__Bookingov__RoomI__5FBE24CE");

                    b.Navigation("CvrNavigation");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("DABAflevering2.Chairman", b =>
                {
                    b.HasOne("DABAflevering2.Society", "CvrNavigation")
                        .WithMany("Chairmen")
                        .HasForeignKey("Cvr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Chairman__CVR__53584DE9");

                    b.Navigation("CvrNavigation");
                });

            modelBuilder.Entity("DABAflevering2.Member", b =>
                {
                    b.HasOne("DABAflevering2.Society", "CvrNavigation")
                        .WithMany("Memberships")
                        .HasForeignKey("CvrNavigationCvr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CvrNavigation");
                });

            modelBuilder.Entity("DABAflevering2.Property", b =>
                {
                    b.HasOne("DABAflevering2.Room", "Room")
                        .WithOne("Property")
                        .HasForeignKey("DABAflevering2.Property", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__propertie__RoomI__5BED93EA");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("DABAflevering2.Room", b =>
                {
                    b.HasOne("DABAflevering2.Municipality", "Municipality")
                        .WithMany("Rooms")
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__rooms__Municipal__5728DECD");

                    b.Navigation("Municipality");
                });

            modelBuilder.Entity("DABAflevering2.Society", b =>
                {
                    b.HasOne("DABAflevering2.Municipality", "Municipality")
                        .WithMany("Societies")
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Societies__Munic__4F87BD05");

                    b.Navigation("Municipality");
                });

            modelBuilder.Entity("DABAflevering2.Municipality", b =>
                {
                    b.Navigation("Rooms");

                    b.Navigation("Societies");
                });

            modelBuilder.Entity("DABAflevering2.Room", b =>
                {
                    b.Navigation("Bookingoverviews");

                    b.Navigation("Property")
                        .IsRequired();
                });

            modelBuilder.Entity("DABAflevering2.Society", b =>
                {
                    b.Navigation("Bookingoverviews");

                    b.Navigation("Chairmen");

                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
