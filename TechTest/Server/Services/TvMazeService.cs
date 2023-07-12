namespace TechTest.Server.Services;
public class TvMazeService : ITvMazeService
{
    private readonly HttpClient _httpClient;

    private const string BaseAddress = "https://api.tvmaze.com";

    public TvMazeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(BaseAddress);
    }

    public async Task<List<TvMazeShow>> GetShowsFromSource()
    {
        const int maxResult = 250;
        var resultCount = 0;
        var allShows = new List<TvMazeShow>();

        while (resultCount <= maxResult)
        {
            var page = resultCount / maxResult;

            var result = await _httpClient.GetAsync($"/shows?page={page}");

            var returnedShows = await result.Content.ReadFromJsonAsync<List<TvMazeShow>>() ?? new List<TvMazeShow>();

            resultCount = returnedShows.Count;

            allShows.AddRange(returnedShows);

            // Avoid throttling on API
            Thread.Sleep(2000);
        }

        return allShows;
    }
}