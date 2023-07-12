using TechTest.Repositories.Genres;

namespace TechTest.Bll.Genres;

public class BlGenres : IBlGenres
{
    private readonly IGenresRepository _genresRepo;

    public BlGenres(IGenresRepository genresRepo)
    {
        _genresRepo = genresRepo;
    }

    public async Task<List<Genre>> GetAllGenres()
    {
        return await _genresRepo.GetAllGenres();
    }

    public async Task<KeyValuePair<bool, string>> SaveGenres(List<Genre> genresToSave)
    {
        return await _genresRepo.Save(genresToSave);
    }
}