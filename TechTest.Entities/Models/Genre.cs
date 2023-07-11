namespace TechTest.Entities.Models;

public class Genre
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<ShowGenre> ShowGenres { get; set; }
}