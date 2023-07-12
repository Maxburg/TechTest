namespace TechTest.Repositories.Shows;

public class ShowsRepository : IShowsRepository
{
    private readonly LocalDbContext _localDbContext;

    public ShowsRepository(LocalDbContext localDbContext)
    {
        _localDbContext = localDbContext;
    }

    public IEnumerable<Show> GetAllShows()
    {
        return _localDbContext.Shows.AsEnumerable();
    }

    public IEnumerable<Show> GetShowsByName(string name)
    {
        return _localDbContext.Shows.Where(x => x.Name.StartsWith(name));
    }

    public async Task<KeyValuePair<bool, string>> Save(IEnumerable<Show> shows)
    {
        // Update shows that already exist
        foreach (var show in shows)
        {
            var dbShow = _localDbContext.Shows.FirstOrDefault(x => x.Id == show.Id);
            if (dbShow != null)
            {
                dbShow.Summary = show.Summary;
                dbShow.Premiered = show.Premiered;
                dbShow.Name = show.Name;
                dbShow.Language = show.Language;
                continue;
            }
            _localDbContext.Add(show);
        }
        var changes = await _localDbContext.SaveChangesAsync();

        return changes == 0 ? new KeyValuePair<bool, string>(false, "Nothing has been saved.") : new KeyValuePair<bool, string>(true, "Success!");
    }
}