using PeopleOverview.Models;
using PeopleOverview.Services;
using Microsoft.AspNetCore.Mvc;

namespace PeopleOverview.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleOverviewController : ControllerBase
{
    public PeopleOverviewController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Person>> GetAll() => PersonService.GetAll();
    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Person> Get(int id)
    {
        var person = PersonService.Get(id);

        if(person == null)
            return NotFound();

        return person;
    }
    // POST action
    [HttpPost]
    public IActionResult Create(Person person)
    {            
        PersonService.Add(person);
        return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
    }
    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Person person)
    {
        if (id != person.Id)
            return BadRequest();
            
        var existingPerson = PersonService.Get(id);
        if(existingPerson is null)
            return NotFound();
    
        PersonService.Update(person);           
    
        return NoContent();
    }
    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var person = PersonService.Get(id);
    
        if (person is null)
            return NotFound();
        
        PersonService.Delete(id);
    
        return NoContent();
    }
}