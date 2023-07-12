namespace TechTest.Bll.Shows;

public interface IBlShows
{
    public IEnumerable<Show> GetAllShows();
    public IEnumerable<Show> GetShowsByName(string name);
    public Task<KeyValuePair<bool, string>> Save(IEnumerable<Show> showsToUpdate);
}