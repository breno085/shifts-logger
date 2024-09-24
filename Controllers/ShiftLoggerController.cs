using Microsoft.AspNetCore.Mvc;
using shifts_logger.Context;
using shifts_logger.Models;

namespace shifts_logger.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShiftLoggerController : ControllerBase
{
    private readonly ShiftLoggerContext _context;

    public ShiftLoggerController(ShiftLoggerContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var shift = _context.Shifts.Find(id);

        if (shift == null) return NotFound();

        return Ok(shift);
    }

    [HttpGet("Name")]
    public IActionResult GetByName(string name)
    {
        var shift = _context.Shifts.Where(x => x.Name == name).FirstOrDefault();

        if (shift == null) return NotFound();

        return Ok(shift);
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var shifts = _context.Shifts.ToList();

        if (!shifts.Any())
        {
            return Ok(new { mensage = "The database is empty." });
        }

        return Ok(shifts);
    }

    [HttpPost]
    public IActionResult Create(ShiftLogger shift)
    {
        // shift.Duration = Duration.CalculateDuration(shift);

        if (shift == null)
        {
            return BadRequest("Shift data is required.");
        }

        _context.Add(shift);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = shift.Id }, shift);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, ShiftLogger shift)
    {
        var shiftDatabase = _context.Shifts.Find(id);

        if (shiftDatabase == null)
            return NotFound();

        shiftDatabase.Name = shift.Name;
        shiftDatabase.Start = shift.Start;
        shiftDatabase.End = shift.End;
        shiftDatabase.Duration = shift.Duration;

        _context.Shifts.Update(shiftDatabase);
        _context.SaveChanges();

        return Ok(shiftDatabase);
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var shiftDatabase = _context.Shifts.Find(id);

        if (shiftDatabase == null)
            return NotFound();

        _context.Shifts.Remove(shiftDatabase);
        _context.SaveChanges();
        
        return NoContent();
    }
}