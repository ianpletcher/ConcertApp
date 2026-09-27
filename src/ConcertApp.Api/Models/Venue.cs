namespace ConcertApi.Models;

public enum VenueType
{
    Amphitheater,
    Bar,
    Club,
    Standalone,
    Arena,
    Stadium,
    ConcertHall,
}

public class Venue
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string? State { get; set; }

    public string Country { get; set; } = string.Empty;

    public bool? ServesAlcohol { get; set; }

    public bool? AllAges { get; set; }

    public VenueType Type { get; set; }
}
