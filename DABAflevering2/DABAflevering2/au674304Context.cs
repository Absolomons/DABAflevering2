using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DABAflevering2
{
    public partial class au674304Context : DbContext
    {
        public au674304Context()
        {
        }

        public au674304Context(DbContextOptions<au674304Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Bookingoverview> Bookingoverviews { get; set; } = null!;
        public virtual DbSet<Chairman> Chairmen { get; set; } = null!;
        public virtual DbSet<Municipality> Municipalities { get; set; } = null!;
        public virtual DbSet<Property> Properties { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Society> Societies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Dab2;User ID=SA;Password=<STRONG6969>; TrustServerCertificate=true");
                optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog = DAB22; User ID = SA; Password =< SuperDuperPassword1!1 >; TrustServerCertificate = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookingoverview>(entity =>
            {
                entity.HasKey(e => new {e.RoomId, e.BookingStart, e.BookingEnd})
                    .HasName("PK__Bookingo__93FCB6C609F9E8D2");

                entity.ToTable("Bookingoverview");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.Cvr).HasColumnName("CVR");

                entity.HasOne(d => d.CvrNavigation)
                    .WithMany(p => p.Bookingoverviews)
                    .HasForeignKey(d => d.Cvr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bookingover__CVR__5ECA0095");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookingoverviews)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bookingov__RoomI__5FBE24CE");
            });

            modelBuilder.Entity<Chairman>(entity =>
            {
                entity.HasKey(e => e.Cpr)
                    .HasName("PK__Chairman__C1F8973CD4538063");

                entity.ToTable("Chairman");

                entity.HasIndex(e => e.Cpr, "UQ__Chairman__C1F8973DC623382E")
                    .IsUnique();

                entity.Property(e => e.Cpr)
                    .ValueGeneratedNever()
                    .HasColumnName("CPR");

                entity.Property(e => e.ChairmanName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Cvr).HasColumnName("CVR");

                entity.Property(e => e.HomeAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.CvrNavigation)
                    .WithMany(p => p.Chairmen)
                    .HasForeignKey(d => d.Cvr)
                    .HasConstraintName("FK__Chairman__CVR__53584DE9");
            });

            modelBuilder.Entity<Municipality>(entity =>
            {
                entity.ToTable("Municipality");

                entity.HasIndex(e => e.MunicipalityId, "UQ__Municipa__009B60F4FC02DE25")
                    .IsUnique();

                entity.Property(e => e.MunicipalityId)
                    .ValueGeneratedNever()
                    .HasColumnName("MunicipalityID");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("properties");

                entity.HasIndex(e => e.RoomId, "UQ__properti__328639182028850B")
                    .IsUnique();

                entity.HasIndex(e => e.PropertyId, "UQ__properti__9C0B8C5CE91EE6F5")
                    .IsUnique();

                entity.Property(e => e.PropertyId)
                    .ValueGeneratedNever()
                    .HasColumnName("propertyID");

                entity.Property(e => e.Coffee).HasColumnName("coffee");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.SoccerGoals).HasColumnName("soccerGoals");

                entity.Property(e => e.Whiteboard).HasColumnName("whiteboard");

                entity.HasOne(d => d.Room)
                    .WithOne(p => p.Property)
                    .HasForeignKey<Property>(d => d.RoomId)
                    .HasConstraintName("FK__propertie__RoomI__5BED93EA");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("rooms");

                entity.HasIndex(e => e.RoomId, "UQ__rooms__32863918C12586CE")
                    .IsUnique();

                entity.Property(e => e.RoomId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoomID");

                entity.Property(e => e.MunicipalityId).HasColumnName("MunicipalityID");

                entity.Property(e => e.Roomlimit).HasColumnName("roomlimit");

                entity.HasOne(d => d.Municipality)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.MunicipalityId)
                    .HasConstraintName("FK__rooms__Municipal__5728DECD");
            });

            modelBuilder.Entity<Society>(entity =>
            {
                entity.HasKey(e => e.Cvr)
                    .HasName("PK__Societie__C1FE224CA7F4BA4B");

                entity.HasIndex(e => e.Cvr, "UQ__Societie__C1FE224D644D06EE")
                    .IsUnique();

                entity.Property(e => e.Cvr)
                    .ValueGeneratedNever()
                    .HasColumnName("CVR");

                entity.Property(e => e.Activity)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.MunicipalityId).HasColumnName("MunicipalityID");

                entity.HasOne(d => d.Municipality)
                    .WithMany(p => p.Societies)
                    .HasForeignKey(d => d.MunicipalityId)
                    .HasConstraintName("FK__Societies__Munic__4F87BD05");
            });

            modelBuilder.Entity<Municipality>().HasData(new Municipality{MunicipalityId = 1});
            modelBuilder.Entity<Municipality>().HasData(new Municipality {});
            modelBuilder.Entity<Society>().HasData(new Society
                {MunicipalityId = 1, NumberOfMembers = 20, Cvr = 1234, Activity = "Volleyball",SocAddress = "Beach"});

            modelBuilder.Entity<Society>().HasData(new Society
                { MunicipalityId = 1, NumberOfMembers = 25, Cvr = 4321, Activity = "Yoga", SocAddress = "Damp Cellar" });

            modelBuilder.Entity<Chairman>().HasData(new Chairman
                { Cvr = 1234, ChairmanName = "bossman", Cpr = 2312, HomeAddress = "Bygning" });
            modelBuilder.Entity<Chairman>().HasData(new Chairman
                { Cvr = 4321, ChairmanName = "Stol", Cpr = 6421, HomeAddress = "Bygning2" });

            modelBuilder.Entity<Member>().HasData(new Member {Cpr = 123451, CvrNavigationCvr = 1234, Name = "Sorry John"});
            modelBuilder.Entity<Member>().HasData(new Member { Cpr = 542124, CvrNavigationCvr = 4321, Name = "Sorry Jens" });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                MunicipalityId = 1, RoomAddress = "Skanderborg", RoomId = 12, Roomlimit = 50, AccessCode = 5454,
                TimespanStart = new DateTime(2022, 12, 24), TimespanEnd = new DateTime(2023, 12, 24)});

            modelBuilder.Entity<Room>().HasData(new Room
            {
                MunicipalityId = 1,
                RoomAddress = "Silkeborg",
                RoomId = 21,
                Roomlimit = 51,
                AccessCode = 1111,
                TimespanStart = new DateTime(1985, 1, 24),
                TimespanEnd = new DateTime(2065, 12, 23)
            });

            modelBuilder.Entity<Property>().HasData(new Property
                {Coffee = false, PropertyId = 1, RoomId = 12, SoccerGoals = true, Whiteboard = true, WiFi = false});

            modelBuilder.Entity<Property>().HasData(new Property
                { Coffee = true, PropertyId = 2, RoomId = 21, SoccerGoals = true, Whiteboard = false, WiFi = true });

            modelBuilder.Entity<Bookingoverview>().HasData(new Bookingoverview {Cvr = 1234,RoomId = 12,BookingStart = new DateTime(2023,2,28), BookingEnd = new DateTime(2023,5,20)});

            modelBuilder.Entity<Bookingoverview>().HasData(new Bookingoverview { Cvr = 4321, RoomId = 21, BookingStart = new DateTime(1999, 3, 2), BookingEnd = new DateTime(2042, 1, 31) });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
