using Microsoft.EntityFrameworkCore;

namespace UltraPlayApi.Models;

public partial class UltraPlayContext : DbContext
{
    public UltraPlayContext()
    {
    }

    public UltraPlayContext(DbContextOptions<UltraPlayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bet> Bets { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<MatchType> MatchTypes { get; set; }

    public virtual DbSet<Odd> Odds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Bets_Bets");

            entity.ToTable("Bets", "Bets");

            entity.Property(e => e.ExternalId).HasComment("Id comming from xml feed");
            entity.Property(e => e.MatchId).HasComment("Connects to the Id of Matches.Matches");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.HasOne(d => d.Match).WithMany(p => p.Bets)
                .HasForeignKey(d => d.MatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bets_MatchId_Matches_Id");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Events_Events");

            entity.ToTable("Events", "Events");

            entity.Property(e => e.CategoryId).HasComment("Id comming from xml feed");
            entity.Property(e => e.ExternalId).HasComment("Id comming from xml feed");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Matches_Matches");

            entity.ToTable("Matches", "Matches");

            entity.Property(e => e.EventId).HasComment("Connects to the Id of Events.Events");
            entity.Property(e => e.MatchTypeId).HasComment("Connects to the Id of Matches.MatchTypes");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.StartDate)
                .HasComment("Id comming from xml feed")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Event).WithMany(p => p.Matches)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_EventId_Events_Id");

            entity.HasOne(d => d.MatchType).WithMany(p => p.Matches)
                .HasForeignKey(d => d.MatchTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_MatchTypeId_MatchTypes_Id");
        });

        modelBuilder.Entity<MatchType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Matches_MatchTypes");

            entity.ToTable("MatchTypes", "Matches");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Type)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Prematch/Live");
        });

        modelBuilder.Entity<Odd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Odds_Odds");

            entity.ToTable("Odds", "Odds");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BetId).HasComment("Connects to the Id of Bets.Bets");
            entity.Property(e => e.ExternalId).HasComment("Id comming from xml feed");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.SpecialBetValue).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.Value).HasColumnType("decimal(3, 2)");

            entity.HasOne(d => d.Bet).WithMany(p => p.Odds)
                .HasForeignKey(d => d.BetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Odds_BetId_Bets_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
