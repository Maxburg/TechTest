namespace TechTest.Entities.Models;

public class LocalDbContext : DbContext
{
    public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options)
    {

    }

    public LocalDbContext() { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Show>().HasKey(x => x.Id);

        builder.Entity<Genre>().HasKey(x => x.Id);

        builder.Entity<Show>()
            .HasMany(x => x.Genres)
            .WithMany(x => x.Shows)
            .UsingEntity<ShowGenre>(
                c => c.HasOne(c => c.Genre)
                    .WithMany()
                    .HasForeignKey(x => x.GenreId),
                c => c.HasOne(x => x.Show)
                    .WithMany()
                    .HasForeignKey(x => x.ShowId)
            );
    }

    public DbSet<Show> Shows { get; set; }
    public DbSet<Genre> Genres { get; set; }
}