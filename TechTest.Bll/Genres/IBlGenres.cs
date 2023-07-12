namespace TechTest.Bll.Genres;
public interface IBlGenres
{
    public Task<List<Genre>> GetAllGenres();
    public Task<KeyValuePair<bool, string>> SaveGenres(List<Genre> genresToSave);
}