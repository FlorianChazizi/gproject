namespace MyWebApp.Helpers
{
    public static class TimeRangeUtility
    {
        public static string GetCommonTimeRange(string timeRange1, string timeRange2)
        {
            try
            {
                // Split the two time ranges into start and end times
                string[] parts1 = timeRange1.Split(" - ");
                string[] parts2 = timeRange2.Split(" - ");

                // Parse the start and end times into DateTime
                DateTime start1 = DateTime.Parse(parts1[0]);
                DateTime end1 = DateTime.Parse(parts1[1]);

                DateTime start2 = DateTime.Parse(parts2[0]);
                DateTime end2 = DateTime.Parse(parts2[1]);

                // Find the maximum of the start times and minimum of the end times
                DateTime commonStart = start1 > start2 ? start1 : start2;
                DateTime commonEnd = end1 < end2 ? end1 : end2;

                // If there is no overlap, return "No overlap"
                if (commonStart >= commonEnd)
                {
                    return "No overlapping time.";
                }

                // Return the overlapping time range in HH:mm format
                return $"{commonStart:HH:mm} - {commonEnd:HH:mm}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
