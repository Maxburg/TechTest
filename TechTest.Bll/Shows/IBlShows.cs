namespace TechTest.Bll.Shows;

public interface IBlShows
{
    public Task<KeyValuePair<bool, string>> Save(IEnumerable<Show> showsToUpdate);
}