using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace practicandoParaTPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonaController : ControllerBase
{

    private readonly Data.AppDbContext _context;
    public PersonaController(Data.AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Get()
    {
        var personas = _context.Personas.ToList();
        return Ok(personas);
    }
    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var persona = _context.Personas.Find(id);
        if (persona == null)
        {
            return NotFound();
        }
        return Ok(persona);
    }
    [HttpPost]
    public IActionResult Post([FromBody] Data.Persona persona)
    {
        _context.Personas.Add(persona);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = persona.Id }, persona);
    }
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] Data.Persona updatedPersona)
    {
        var persona = _context.Personas.Find(id);
        if (persona == null)
        {
            return NotFound();
        }
        persona.Nombre = updatedPersona.Nombre;
        persona.edad = updatedPersona.edad;
        _context.Personas.Update(persona);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var persona = _context.Personas.Find(id);
        if (persona == null)
        {
            return NotFound();
        }
        _context.Personas.Remove(persona);
        _context.SaveChanges();
        return NoContent();
    }

}
