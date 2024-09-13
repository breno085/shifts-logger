using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shifts_logger.Models;

public class ShiftLogger
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Start { get; set; }
    public string End { get; set; }
    public string Duration { get; set; }
}