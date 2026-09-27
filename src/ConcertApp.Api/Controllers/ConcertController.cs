using ConcertApi.Models;
using ConcertApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConcertApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ConcertController : ControllerBase
{
    private readonly ConcertService _service;

    public ConcertController(ConcertService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Concert>> GetAll() => _service.GetConcerts();

    [HttpGet("{id}")]
    public ActionResult<Concert> Get(int id)
    {
        var returnedConcert = _service.GetConcertById(id);

        if (returnedConcert == null)
        {
            return NotFound();
        }
        return returnedConcert;
    }

    [HttpPost]
    public IActionResult Create(Concert concert)
    {
        _service.AddConcert(concert);
        return CreatedAtAction(nameof(Get), new { id = concert.Id }, concert);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Concert updatedConcert)
    {
        _service.Update(id, updatedConcert);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingConcert = _service.GetConcertById(id);
        if (existingConcert == null)
        {
            return NotFound();
        }
        _service.DeleteConcert(id);
        return NoContent();
    }
}
