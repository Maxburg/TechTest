using TechTest.Bll.Shows;
using TechTest.Repositories.ShowGenres;

namespace TechTest.Bll.ShowGenres;

public class BlShowGenres : IBlShowGenres
{
    private readonly IShowGenresRepository _showGenresRepo;

    public BlShowGenres(IShowGenresRepository showGenresRepo)
    {
        _showGenresRepo = showGenresRepo;
    }

    public async Task<KeyValuePair<bool, string>> Save(List<ShowGenre> showGenresToSave)
    {
        return await _showGenresRepo.Save(showGenresToSave);
    }
}