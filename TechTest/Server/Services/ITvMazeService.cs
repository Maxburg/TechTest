namespace TechTest.Server.Services;

public interface ITvMazeService
{
    public Task<List<TvMazeShow>> GetShowsFromSource();
}