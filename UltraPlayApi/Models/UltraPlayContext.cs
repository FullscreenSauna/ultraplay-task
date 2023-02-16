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

    public virtual DbSet<Odd> Odds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bet>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Name).IsRequired();
            entity.Property(b => b.ExternalId).IsRequired();
            entity.Property(b => b.IsLive).IsRequired();
            entity.HasMany(b => b.Odds);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.ExternalId).IsRequired();
            entity.Property(e => e.IsLive).IsRequired();
            entity.Property(e => e.CategoryID).IsRequired();
            entity.HasMany(e => e.Matches);
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Name).IsRequired();
            entity.Property(m => m.ExternalId).IsRequired();
            entity.Property(m => m.StartDate).IsRequired();
            entity.Property(m => m.MatchType).IsRequired();
            entity.HasMany(m => m.Bets);
        });

        modelBuilder.Entity<Odd>(entity =>
        {
            entity.HasKey(o => o.Id);
            entity.Property(o => o.Name).IsRequired();
            entity.Property(o => o.ExternalId).IsRequired();
            entity.Property(o => o.Value).IsRequired();
            entity.Property(o => o.SpecialBetValue);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
