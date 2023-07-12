namespace TechTest.Repositories.Shows;

public interface IShowsRepository
{
    public IEnumerable<Show> GetAllShows();
    public IEnumerable<Show> GetShowsByName(string name);
    public Task<KeyValuePair<bool, string>> Save(IEnumerable<Show> shows);
}