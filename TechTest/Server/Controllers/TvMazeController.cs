namespace TechTest.Server.Controllers
{
    public class TvMazeController : Controller
    {
        private readonly IBlShows _blShows;

        private readonly IBlGenres _blGenres;

        private readonly IBlShowGenres _blShowGenres;

        private readonly ITvMazeService _tvMazeService;

        public TvMazeController(IBlShows blShows, IBlGenres blGenres, IBlShowGenres blShowGenres, ITvMazeService tvMazeService)
        {
            _blShows = blShows;
            _blGenres = blGenres;
            _blShowGenres = blShowGenres;
            _tvMazeService = tvMazeService;
        }

        [HttpPost]
        public async Task<KeyValuePair<bool, string>> UpdateShowsFromSource()
        {
            // Call to TvMaze
            var allShows = await _tvMazeService.GetShowsFromSource();

            var allGenresOgList = allShows.SelectMany(x => x.Genres).Distinct().ToList();

            // Update Genres in db
            var allGenres = allGenresOgList.Select(genre => new Genre()
            {
                Name = genre
            });

            var saveResult = await _blGenres.SaveGenres(allGenres.ToList());
            if (!saveResult.Key) return saveResult;

            var genresFromDb = await _blGenres.GetAllGenres();

            // Update shows in db
            var showsToSave = allShows.Select(show => new Show()
            {
                AddedByUser = false,
                Id = show.Id,
                Language = show.Language,
                Name = show.Name,
                Premiered = DateTime.ParseExact(show.Premiered, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Summary = show.Summary
            }).Where(x => x.Premiered > new DateTime(2014, 1, 1));

            var showGenresToSave = new List<ShowGenre>();

            // Update showgenres in db
            foreach (var show in allShows)
            {
                var showGenres = show.Genres.Select(showGenre => new ShowGenre()
                {
                    GenreId = genresFromDb.FirstOrDefault(x => x.Name == showGenre)!.Id,
                    ShowId = show.Id
                });

                showGenresToSave.AddRange(showGenres.ToList());
            }

            saveResult = await _blShows.Save(showsToSave);
            if (!saveResult.Key) return saveResult;

            saveResult = await _blShowGenres.Save(showGenresToSave);

            // return
            return saveResult;
        }
    }
}
