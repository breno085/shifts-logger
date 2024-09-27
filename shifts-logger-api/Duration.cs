using shifts_logger.Models;

namespace shifts_logger
{
    public static class Duration
    {
        public static string CalculateDuration(ShiftLogger shift)
        {
            TimeSpan start = TimeSpan.Parse(shift.Start);
            TimeSpan end = TimeSpan.Parse(shift.End);

            TimeSpan duration = end - start;

            if (duration < TimeSpan.Zero)
            {
                duration += TimeSpan.FromHours(24);  // Adjust for overnight shifts
            }

            shift.Duration = duration.ToString(@"hh\:mm");

            return shift.Duration;
        }
    }
}