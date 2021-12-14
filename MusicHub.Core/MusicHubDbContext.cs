namespace MusicHub.Core
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Infrastructure;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {

        }

        public MusicHubDbContext(DbContextOptions<MusicHubDbContext> options)
            : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Performer> Performers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SongPerformer>(a => { a.HasKey(b => new { b.PerformerId, b.SongId }); });
            builder.Entity<Song>(s => s.Property(p => p.PictureURL).IsUnicode(false));
        }
    }
}
