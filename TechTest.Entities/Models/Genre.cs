namespace TechTest.Entities.Models;

public class Genre
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}