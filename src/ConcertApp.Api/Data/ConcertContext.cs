using ConcertApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertApi.Data;

public class ConcertContext : DbContext
{
    public ConcertContext(DbContextOptions<ConcertContext> options)
        : base(options) { }

    public DbSet<Concert>? Concerts { get; set; }
    public DbSet<Venue>? Venues { get; set; }
    public DbSet<Artist>? Artists { get; set; }
}
