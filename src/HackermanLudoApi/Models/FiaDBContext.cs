using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace HackermanLudoApi.Models
{
    public partial class FiaDBContext : DbContext
    {
        public FiaDBContext()
        {
        }

        public FiaDBContext(DbContextOptions<FiaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Pieces> Pieces { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Tile> Tile { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration["ConnectionStrings:FiaDB"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Game>().HasMany(g => g.Players).WithOne();

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Pieces>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PlayerColor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");
            });

            modelBuilder.Entity<Player>().HasOne(p => p.Game).WithMany(b => b.Players).HasForeignKey(p => p.GameId);

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.UserId).HasColumnName("UserID");


            });

            modelBuilder.Entity<Tile>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PieceId).HasColumnName("PieceID");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
