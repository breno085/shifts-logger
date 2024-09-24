using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shifts_logger.Context;

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

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var shifts = _context.Shifts.ToList();

        if (!shifts.Any())
        {
            return Ok(new { mensagem = "The database is empty." });
        }

        return Ok(shifts);  
    }

}