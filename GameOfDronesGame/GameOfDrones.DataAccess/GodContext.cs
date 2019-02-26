
namespace GameOfDrones.DataAccess
{
    using GameOfDrones.DataAccess.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    public partial class GodContext : DbContext
    {

        /// <summary>
        /// Initializes a new instance of the context class
        /// </summary>
        /// <param name="options"></param>
        public GodContext(DbContextOptions<GodContext> options) : base(options)
        {
        }

        /// <summary>
        /// Further configure models
        /// </summary>
        /// <param name="modelBuilder">Model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.ToTable("Game", "dbo");

                entity.HasIndex(e => e.WinnerId)
                    .HasName("index_GameWinner");

                entity.HasIndex(e => e.WinnerId)
                    .HasName("index_GameOpponent");

                entity.HasOne(d => d.Winner)
                    .WithMany(p => p.Victories)
                    .HasForeignKey(d => d.WinnerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Winner");

                entity.HasOne(d => d.Opponent)
                    .WithMany(p => p.Defeats)
                    .HasForeignKey(d => d.OpponentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Opponent");
            });


            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.ToTable("Player", "dbo");

               entity.HasIndex(e => e.PlayerName)
                   .HasName("index_PlayerName");
            });

            modelBuilder.Entity<Logging>(entity =>
            {
                entity.HasKey(e => e.LoggingId);

                entity.ToTable("Logging", "dbo");
            });
        }

        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Logging> Logging { get; set; }
    }
}
