using Microsoft.AspNetCore.Mvc;
using RESTfull.Domain.Entities;
using RESTfull.Infrastructure.Repository;

[ApiController]
[Route("api/[controller]")]
public class ConferencesController : ControllerBase
{
    private readonly IRepository<Conference> _repository;

    public ConferencesController(IRepository<Conference> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var conference = await _repository.GetByIdAsync(id);
        return conference == null ? NotFound() : Ok(conference);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Conference conference)
    {
        // Очищаем навигационные свойства ПЕРЕД валидацией
        conference.Venue = null;
        conference.Directions = null;

        // Удаляем ошибки валидации для навигационных свойств
        ModelState.Remove(nameof(Conference.Venue));
        ModelState.Remove(nameof(Conference.Directions));

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _repository.AddAsync(conference);
        return CreatedAtAction(nameof(GetById), new { id = conference.Id }, conference);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Conference conference)
    {
        if (id != conference.Id)
            return BadRequest();

        // Очищаем навигационные свойства ПЕРЕД валидацией
        conference.Venue = null;
        conference.Directions = null;

        // Удаляем ошибки валидации для навигационных свойств
        ModelState.Remove(nameof(Conference.Venue));
        ModelState.Remove(nameof(Conference.Directions));

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _repository.UpdateAsync(conference);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
