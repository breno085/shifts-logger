using shifts_logger.Models;
using Microsoft.EntityFrameworkCore;

namespace shifts_logger.Context;

public class ShiftLoggerContext : DbContext
{
    public ShiftLoggerContext(DbContextOptions<ShiftLoggerContext> options)
        : base(options)
    {
    }
    public DbSet<ShiftLogger> Shifts { get; set; }
}