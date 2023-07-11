namespace TechTest.Entities.Models;

public class ShowGenre
{
    [ForeignKey("ShowId")]
    public Show Show { get; set; }

    [ForeignKey("GenreId")]
    public Genre Genre { get; set; }

    public int ShowId { get; set; }

    public int GenreId { get; set; }
}