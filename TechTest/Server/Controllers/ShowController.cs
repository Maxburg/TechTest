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
    public IEnumerable<ShowViewModel> Get()
    {
        var allShows = _blShows.GetAllShows();

        var showViewModels = allShows.Select(show => new ShowViewModel()
        {
            Id = show.Id,
            Name = show.Name,
            Language = show.Language,
            Premiered = show.Premiered,
            Summary = show.Summary
        })
            .ToList();

        return showViewModels;
    }

    [HttpGet]
    public IEnumerable<ShowViewModel> GetShowByName(string name)
    {
        var foundShows = _blShows.GetShowsByName(name);

        var showViewModels = foundShows.Select(show => new ShowViewModel()
        {
            Id = show.Id,
            Name = show.Name,
            Language = show.Language,
            Premiered = show.Premiered,
            Summary = show.Summary
        });

        return showViewModels;
    }

    [HttpPost]
    public async Task<KeyValuePair<bool, string>> UpdateShows(IEnumerable<ShowViewModel> showViewModels)
    {
        var showsToSave = showViewModels.Select(showViewModel => new Show()
        {
            Id = showViewModel.Id,
            Name = showViewModel.Name,
            Premiered = showViewModel.Premiered,
            Language = showViewModel.Language,
            Summary = showViewModel.Summary
        })
            .ToList();

        var result = await _blShows.Save(showsToSave);

        return result;
    }
}