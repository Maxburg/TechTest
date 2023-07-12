using System;
namespace TechTest.Entities.Models;

public class Show
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Language { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    public DateTime Premiered { get; set; }

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

    public bool AddedByUser { get; set; }
}