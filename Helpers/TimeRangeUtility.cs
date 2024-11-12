using System;
using System.Globalization;

namespace MyWebApp.Helpers
{
    public class TimeRange
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public TimeRange(DateTime start, DateTime end)
        {
            if (start > end)
                throw new ArgumentException("Start time must be before or equal to end time.");

            Start = start;
            End = end;
        }

        public static string GetOverlap(TimeRange range1, TimeRange range2)
        {
            // Check if dates are different; if so, return "No Overlapping Time."
            if (range1.Start.Date != range2.Start.Date)
            {
                return "No Overlapping Time";
            }

            // Calculate overlap
            var overlapStart = range1.Start > range2.Start ? range1.Start : range2.Start;
            var overlapEnd = range1.End < range2.End ? range1.End : range2.End;

            // Check for actual overlap
            if (overlapStart < overlapEnd)
            {
                return $"{overlapStart:HH:mm} - {overlapEnd:HH:mm}";
            }

            return "No Overlapping Time";
        }

        public static TimeRange ParseTimeRange(string timeRangeInput)
        {
            // Expected format: "yyyy-MM-dd HH:mm - HH:mm"
            var parts = timeRangeInput.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
                throw new FormatException("Invalid time range format.");

            // Parse date and start time (first part) and end time (second part)
            var start = DateTime.ParseExact(parts[0].Trim(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            var end = DateTime.ParseExact($"{start:yyyy-MM-dd} {parts[1].Trim()}", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

            if (start > end)
                throw new ArgumentException("Start time must be before or equal to end time.");

            return new TimeRange(start, end);
        }
    }
}
