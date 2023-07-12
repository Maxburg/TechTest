namespace TechTest.Entities.Models;

public class ShowGenre
{
    [ForeignKey("ShowId")]
    public Show Show { get; set; } = new();

    [ForeignKey("GenreId")]
    public Genre Genre { get; set; } = new();

    public int ShowId { get; set; }

    public int GenreId { get; set; }
}