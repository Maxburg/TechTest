namespace TechTest.Repositories.ShowGenres;

public class ShowGenresRepository : IShowGenresRepository
{
    private readonly LocalDbContext _dbContext;

    public ShowGenresRepository(LocalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<KeyValuePair<bool, string>> Save(List<ShowGenre> genresToSave)
    {
        await _dbContext.AddRangeAsync(genresToSave);

        var saveResult = await _dbContext.SaveChangesAsync();

        return saveResult == 0 ? new KeyValuePair<bool, string>(false, "Nothing has been saved.") : new KeyValuePair<bool, string>(true, "Success!");
    }
}