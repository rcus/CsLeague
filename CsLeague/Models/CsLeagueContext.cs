namespace CsLeague.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CsLeagueContext : DbContext
    {
        public CsLeagueContext()
            : base("name=CsLeague")
        {
        }

        public virtual DbSet<Clans> Clans { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<Players> Players { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clans>()
                .HasMany(e => e.Matches)
                .WithRequired(e => e.Clans)
                .HasForeignKey(e => e.ClanAwayId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clans>()
                .HasMany(e => e.Matches1)
                .WithRequired(e => e.Clans1)
                .HasForeignKey(e => e.ClanHomeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clans>()
                .HasMany(e => e.Players)
                .WithOptional(e => e.Clans)
                .HasForeignKey(e => e.ClanId);
        }
    }
}
