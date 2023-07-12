namespace TechTest.Repositories.Genres;

public class GenresRepository : IGenresRepository
{
    private readonly LocalDbContext _dbContext;

    public GenresRepository(LocalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Genre>> GetAllGenres()
    {
        var genres = await _dbContext.Genres.ToListAsync();

        return genres;
    }

    public async Task<KeyValuePair<bool, string>> Save(List<Genre> genresToSave)
    {
        foreach (var genre in genresToSave)
        {
            var dbGenre = _dbContext.Genres.FirstOrDefault(x => x.Id == genre.Id);
            if (dbGenre != null)
            {
                dbGenre.Name = genre.Name;
                continue;
            }
            _dbContext.Add(genre);
        }
        var changes = await _dbContext.SaveChangesAsync();

        return changes == 0 ? new KeyValuePair<bool, string>(false, "Nothing has been saved.") : new KeyValuePair<bool, string>(true, "Success!");
    }
}