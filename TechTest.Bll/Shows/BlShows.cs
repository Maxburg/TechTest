namespace TechTest.Bll.Shows;

public class BlShows : IBlShows
{
    private readonly IShowsRepository _showRepo;

    public BlShows(IShowsRepository showRepo)
    {
        _showRepo = showRepo;
    }

    public IEnumerable<Show> GetAllShows()
    {
        return _showRepo.GetAllShows();
    }

    public IEnumerable<Show> GetShowsByName(string name)
    {
        return _showRepo.GetShowsByName(name);
    }

    public async Task<KeyValuePair<bool, string>> Save(IEnumerable<Show> showsToUpdate)
    {
        return await _showRepo.Save(showsToUpdate);
    }
}