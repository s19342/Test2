using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Test2.Entities
{
    public partial class TeamContext : DbContext
    {
        public TeamContext()
        {
        }

        public TeamContext(DbContextOptions<TeamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Championship> Championship { get; set; }
        public virtual DbSet<ChampionshipTeam> ChampionshipTeam { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerTeam> PlayerTeam { get; set; }
        public virtual DbSet<Team> Team { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s19342;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Championship>(entity =>
            {
                entity.HasKey(e => e.IdChampionship)
                    .HasName("Championship_pk");

                entity.Property(e => e.OfficialName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ChampionshipTeam>(entity =>
            {
                entity.HasKey(e => new { e.IdChampionship, e.IdTeam })
                    .HasName("Championship_Team_pk");

                entity.ToTable("Championship_Team");

                entity.HasOne(d => d.IdChampionshipNavigation)
                    .WithMany(p => p.ChampionshipTeam)
                    .HasForeignKey(d => d.IdChampionship)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Championship_Team_Championship");

                entity.HasOne(d => d.IdTeamNavigation)
                    .WithMany(p => p.ChampionshipTeam)
                    .HasForeignKey(d => d.IdTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Championship_Team_Team");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.IdPlayer)
                    .HasName("Player_pk");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PlayerTeam>(entity =>
            {
                entity.HasKey(e => new { e.IdPlayer, e.IdTeam })
                    .HasName("Player_Team_pk");

                entity.ToTable("Player_Team");

                entity.Property(e => e.Comment).HasMaxLength(300);

                entity.HasOne(d => d.IdPlayerNavigation)
                    .WithMany(p => p.PlayerTeam)
                    .HasForeignKey(d => d.IdPlayer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Player_Team_Player");

                entity.HasOne(d => d.IdTeamNavigation)
                    .WithMany(p => p.PlayerTeam)
                    .HasForeignKey(d => d.IdTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Player_Team_Team");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.IdTeam)
                    .HasName("Team_pk");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
