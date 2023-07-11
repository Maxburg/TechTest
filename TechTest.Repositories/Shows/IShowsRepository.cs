namespace TechTest.Repositories.Shows;

public interface IShowsRepository
{
    public Task<KeyValuePair<bool, string>> Save(IEnumerable<Show> shows);
}