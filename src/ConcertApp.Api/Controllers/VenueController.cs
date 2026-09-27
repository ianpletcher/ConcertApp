using ConcertApi.Models;
using ConcertApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConcertApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VenueController : ControllerBase
{
    private readonly VenueService _service;

    public VenueController(VenueService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public ActionResult<Venue> Get(int id)
    {
        var returnedVenue = _service.GetVenueById(id);
        if (returnedVenue == null)
        {
            return NotFound();
        }
        return returnedVenue;
    }

    [HttpPost]
    public IActionResult Create(Venue venue)
    {
        _service.AddVenue(venue);
        return CreatedAtAction(nameof(Get), new { id = venue.Id }, venue);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Venue updatedVenue)
    {
        _service.Update(id, updatedVenue);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingConcert = _service.GetVenueById(id);
        if (existingConcert == null)
        {
            return NotFound();
        }
        _service.DeleteVenue(id);
        return NoContent();
    }
}
