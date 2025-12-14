using Microsoft.AspNetCore.Mvc;
using RESTfull.Domain.Entities;
using RESTfull.Infrastructure.Repository;
using System;

[ApiController]
[Route("api/[controller]")]
public class VenuesController : ControllerBase
{
    private readonly IRepository<Venue> _repository;

    public VenuesController(IRepository<Venue> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var venue = await _repository.GetByIdAsync(id);
        return venue == null ? NotFound() : Ok(venue);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Venue venue)
    {
        await _repository.AddAsync(venue);
        return CreatedAtAction(nameof(GetById), new { id = venue.Id }, venue);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Venue venue)
    {
        if (id != venue.Id)
            return BadRequest();

        await _repository.UpdateAsync(venue);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
