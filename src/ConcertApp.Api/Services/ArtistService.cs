using ConcertApi.Data;
using ConcertApi.Models;

namespace ConcertApi.Services;

public class ArtistService
{
    private readonly ConcertContext _context;

    public ArtistService(ConcertContext context)
    {
        _context = context;
    }

    public List<Artist> GetArtists()
    {
        if (_context.Artists != null)
        {
            return _context.Artists.ToList();
        }
        return new List<Artist>();
    }

    public Artist GetArtistById(int id)
    {
        if (_context.Artists != null)
        {
            return _context.Artists.Find(id);
        }
        return null;
    }

    public void AddArtist(Artist artist)
    {
        if (_context.Artists != null)
        {
            _context.Artists.Add(artist);
            _context.SaveChanges();
        }
    }

    public void Update(int id, Artist updatedArtist)
    {
        if (_context.Artists == null)
        {
            return;
        }
        var artist = _context.Artists.Find(id);
        if (artist == null)
        {
            return;
        }
        _context.Entry(artist).CurrentValues.SetValues(updatedArtist);
        _context.SaveChanges();
    }

    public void DeleteArtist(int id)
    {
        if (_context.Artists != null)
        {
            var artistToRemove = _context.Artists.Find(id);

            if (artistToRemove != null)
            {
                _context.Artists.Remove(artistToRemove);
                _context.SaveChanges();
            }
        }
    }
}
