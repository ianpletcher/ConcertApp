namespace ConcertApi.Models;

public class Concert
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public Venue? Venue { get; set; }

    public Artist? Artist { get; set; }

    public string? Support { get; set; }

    public bool? Festival { get; set; }

    public string? TourName { get; set; }
}
