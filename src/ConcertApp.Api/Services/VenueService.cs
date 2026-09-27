using ConcertApi.Data;
using ConcertApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ConcertApi.Services;

public class VenueService
{
    private readonly ConcertContext _context;

    public VenueService(ConcertContext context)
    {
        _context = context;
    }

    public List<Venue> GetVenues()
    {
        if (_context.Venues != null)
        {
            return _context.Venues.ToList();
        }
        return new List<Venue>();
    }

    public Venue GetVenueById(int id)
    {
        if (_context.Venues != null)
        {
            return _context.Venues.Find(id);
        }
        return null;
    }

    public void AddVenue(Venue venue)
    {
        if (_context.Venues != null)
        {
            _context.Venues.Add(venue);
            _context.SaveChanges();
        }
    }

    public void Update(int id, Venue updatedVenue)
    {
        if (_context.Venues == null)
        {
            return;
        }
        var venue = _context.Venues.Find(id);
        if (venue == null)
        {
            return;
        }
        _context.Entry(venue).CurrentValues.SetValues(updatedVenue);
        _context.SaveChanges();
    }

    public void DeleteVenue(int id)
    {
        if (_context.Venues != null)
        {
            var venueToRemove = _context.Venues.Find(id);

            if (venueToRemove != null)
            {
                _context.Venues.Remove(venueToRemove);
                _context.SaveChanges();
            }
        }
    }
}
