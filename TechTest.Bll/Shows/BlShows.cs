namespace TechTest.Bll.Shows;

public class BlShows : IBlShows
{
    private IShowsRepository _showRepo;

    public BlShows(IShowsRepository showRepo)
    {
        _showRepo = showRepo;
    }

    public async Task<KeyValuePair<bool, string>> Save(IEnumerable<Show> showsToUpdate)
    {
        return await _showRepo.Save(showsToUpdate);
    }
}