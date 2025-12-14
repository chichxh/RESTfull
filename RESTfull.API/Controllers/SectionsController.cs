using Microsoft.AspNetCore.Mvc;
using RESTfull.Domain.Entities;
using RESTfull.Infrastructure.Repository;

[ApiController]
[Route("api/[controller]")]
public class SectionsController : ControllerBase
{
    private readonly IRepository<Section> _repository;

    public SectionsController(IRepository<Section> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var section = await _repository.GetByIdAsync(id);
        return section == null ? NotFound() : Ok(section);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Section section)
    {
        await _repository.AddAsync(section);
        return CreatedAtAction(nameof(GetById), new { id = section.Id }, section);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Section section)
    {
        if (id != section.Id)
            return BadRequest();

        await _repository.UpdateAsync(section);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
