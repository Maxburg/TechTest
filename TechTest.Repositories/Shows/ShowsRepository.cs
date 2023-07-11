namespace TechTest.Repositories.Shows;

public class ShowsRepository : IShowsRepository
{
    private LocalDbContext _localDbContext;

    public ShowsRepository(LocalDbContext localDbContext)
    {
        _localDbContext = localDbContext;
    }

    public async Task<KeyValuePair<bool, string>> Save(IEnumerable<Show> shows)
    {
        // Update shows that already exist
        foreach (var show in shows)
        {
            var dbShow = _localDbContext.Shows.FirstOrDefault(x => x.Id == show.Id);
            if (dbShow != null)
            {
                dbShow.ShowGenres = show.ShowGenres;
                dbShow.Summary = show.Summary;
                dbShow.Premiered = show.Premiered;
                dbShow.Name = show.Name;
                dbShow.Language = show.Language;
                continue;
            }
            _localDbContext.Add(show);
        }
        var changes = _localDbContext.SaveChanges();

        if (changes == 0)
        {
            return new KeyValuePair<bool, string>(false, "Nothing has been saved.");
        }
        return new KeyValuePair<bool, string>(true, "Success!");
    }
}