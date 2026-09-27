namespace ConcertApi.Models;

public class Artist
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? DOB { get; set; }

    private int? age;

    public int? Age
    {
        get { return age; }
        set
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            if (DOB == null)
            {
                age = value;
                return;
            }
            else if (DOB > today)
            {
                throw new ArgumentOutOfRangeException("Birthdate must be in the past");
            }
            age = today.Year - DOB?.Year;
        }
    }

    public string? Country { get; set; }
    public string? Genre { get; set; }
    public int Popularity { get; set; }
}
