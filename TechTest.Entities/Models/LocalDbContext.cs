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

        builder.Entity<ShowGenre>().HasKey(table => new
        {
            table.ShowId,
            table.GenreId
        });

        builder.Entity<ShowGenre>().HasOne(sg => sg.Show)
            .WithMany(x => x.ShowGenres).HasForeignKey(x => x.ShowId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<ShowGenre>().HasOne(sg => sg.Genre)
            .WithMany(x => x.ShowGenres).HasForeignKey(x => x.GenreId)
            .OnDelete(DeleteBehavior.Cascade);
    }


    public DbSet<Show> Shows { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<ShowGenre> ShowGenres { get; set; }
}