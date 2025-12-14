using Microsoft.AspNetCore.Mvc;
using RESTfull.Domain.Entities;
using RESTfull.Infrastructure.Repository;
using System;

[ApiController]
[Route("api/[controller]")]
public class PersonsController : ControllerBase
{
    private readonly IRepository<Person> _repository;

    public PersonsController(IRepository<Person> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var person = await _repository.GetByIdAsync(id);
        return person == null ? NotFound() : Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Person person)
    {
        await _repository.AddAsync(person);
        return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Person person)
    {
        if (id != person.Id)
            return BadRequest();

        await _repository.UpdateAsync(person);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
