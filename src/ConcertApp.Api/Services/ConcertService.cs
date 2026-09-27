using ConcertApi.Data;
using ConcertApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ConcertApi.Services;

public class ConcertService
{
    private readonly ConcertContext _context;
    public ConcertService(ConcertContext context)
    {
        _context = context;
    }

    public List<Concert> GetConcerts()
    {
        if (_context.Concerts != null)
        {
            return _context.Concerts.ToList();
        }
        return new List<Concert>();
    }

    public Concert GetConcertById(int id)
    {
        if (_context.Concerts == null)
        {
            return null;
        }
        var concert = _context.Concerts.Find(id);
        return concert;
    }

    public void AddConcert(Concert concert)
    {
        if (_context.Concerts != null)
        {
            _context.Concerts.Add(concert);
            _context.SaveChanges();
        }
    }

    public void Update(int id, Concert updatedConcert)
    {
        if (_context.Concerts == null)
        {
            return;
        }
        var concert = _context.Concerts.Find(id);
        if (concert == null)
        {
            return;
        }
        _context.Entry(concert).CurrentValues.SetValues(updatedConcert);
        _context.SaveChanges();
    }

    public void DeleteConcert(int id)
    {
        if (_context.Concerts != null)
        {
            var concert = _context.Concerts.Find(id);
            if (concert != null)
            {
                _context.Concerts.Remove(concert);
                _context.SaveChanges();
            }
        }
    }
}
