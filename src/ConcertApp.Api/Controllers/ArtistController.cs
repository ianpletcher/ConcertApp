using ConcertApi.Models;
using ConcertApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConcertApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistController : ControllerBase
{
    private readonly ArtistService _service;

    public ArtistController(ArtistService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public ActionResult<Artist> Get(int id)
    {
        var returnedArtist = _service.GetArtistById(id);
        if (returnedArtist == null)
        {
            return NotFound();
        }
        return returnedArtist;
    }

    [HttpPost]
    public IActionResult Create(Artist artist)
    {
        _service.AddArtist(artist);
        return CreatedAtAction(nameof(Get), new { id = artist.Id }, artist);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Artist updatedArtist)
    {
        _service.Update(id, updatedArtist);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var artistToDelete = _service.GetArtistById(id);
        if (artistToDelete == null)
        {
            return NotFound();
        }
        _service.DeleteArtist(id);
        return NoContent();
    }
}
