namespace TechTest.Repositories.Genres;

public interface IGenresRepository
{
    public Task<List<Genre>> GetAllGenres();
    public Task<KeyValuePair<bool, string>> Save(List<Genre> genresToSave);
}