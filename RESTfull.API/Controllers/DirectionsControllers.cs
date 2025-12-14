using Microsoft.AspNetCore.Mvc;
using RESTfull.Domain.Entities;
using RESTfull.Infrastructure.Repository;

[ApiController]
[Route("api/[controller]")]
public class DirectionsController : ControllerBase
{
    private readonly IRepository<Direction> _repository;

    public DirectionsController(IRepository<Direction> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var direction = await _repository.GetByIdAsync(id);
        return direction == null ? NotFound() : Ok(direction);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Direction direction)
    {
        await _repository.AddAsync(direction);
        return CreatedAtAction(nameof(GetById), new { id = direction.Id }, direction);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Direction direction)
    {
        if (id != direction.Id)
            return BadRequest();

        await _repository.UpdateAsync(direction);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
