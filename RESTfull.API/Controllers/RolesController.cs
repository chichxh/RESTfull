using Microsoft.AspNetCore.Mvc;
using RESTfull.Domain.Entities;
using RESTfull.Infrastructure.Repository;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRepository<Role> _repository;

    public RolesController(IRepository<Role> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var role = await _repository.GetByIdAsync(id);
        return role == null ? NotFound() : Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Role role)
    {
        await _repository.AddAsync(role);
        return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Role role)
    {
        if (id != role.Id)
            return BadRequest();

        await _repository.UpdateAsync(role);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
