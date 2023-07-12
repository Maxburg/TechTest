namespace TechTest.Repositories.ShowGenres;

public interface IShowGenresRepository
{
    public Task<KeyValuePair<bool, string>> Save(List<ShowGenre> genresToSave);
}