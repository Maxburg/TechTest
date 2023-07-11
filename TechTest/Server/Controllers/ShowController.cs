

namespace TechTest.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ShowController : ControllerBase
{
    private readonly ILogger<ShowController> _logger;

    private readonly IBlShows _blShows;

    public ShowController(ILogger<ShowController> logger, IBlShows blShows)
    {
        _blShows = blShows;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<ShowViewModel>> Get()
    {
        // Get all Shows
    }

    [HttpGet]
    public async Task<IEnumerable<ShowViewModel>> GetShowById(string name)
    {
        // Get show by name
    }

    [HttpPost]
    public async Task<KeyValuePair<bool, string>> UpdateShows(IEnumerable<ShowViewModel> showViewModels)
    {
        List<Show> showsToSave = new();
        foreach (var showViewModel in showViewModels)
        {
            var show = new Show()
            {
                Id = showViewModel.Id,
                Name = showViewModel.Name,
                Premiered = showViewModel.Premiered,
                Language = showViewModel.Language,
                Summary = showViewModel.Summary
            };
            showsToSave.Add(show);
        }
        var result = await _blShows.Save(showsToSave);
        return result;
    }

    [HttpPost]
    public async Task<KeyValuePair<bool, string>> UpdateShowsFromSource()
    {
        // Call to TvMaze

        // Update shows in db

        // return
    }
}
