namespace WashTimer.App
{
    public record OffsetTimeResult(TimeSpan OffsetRoundedToOneHour, TimeSpan OffsetRoundedToHalfAnHour, TimeSpan OffsetRoundedTo15Minutes)
    {
        public static OffsetTimeResult Zero => new(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero);
    }

    public static class OffsetTimeCalculator
    {
        public static OffsetTimeResult CalculateTimeOffset(DateTime now, TimeSpan targetTime, TimeSpan programLength)
        {
            var targetDate = (now.TimeOfDay >= targetTime ? now.AddDays(1) : now);
            var targetDateAndTime = new DateTime(targetDate.Year, targetDate.Month, targetDate.Day, targetTime.Hours, targetTime.Minutes, targetTime.Seconds);
            var idealProgramStartDateAndTime = targetDateAndTime - programLength;
            if (now >= idealProgramStartDateAndTime) return OffsetTimeResult.Zero;

            var idealOffset = idealProgramStartDateAndTime - now;
           
            var secondsRoundedToOneHour = (int)(idealOffset.TotalSeconds / 3600) * 3600;
            var secondsRoundedToHalfAnHour = (int)(idealOffset.TotalSeconds / 1800) * 1800;
            var secondsRoundedTo15Minutes = (int)(idealOffset.TotalSeconds / 900) * 900;

            return new OffsetTimeResult(
                OffsetRoundedToOneHour: TimeSpan.FromSeconds(secondsRoundedToOneHour),
                OffsetRoundedToHalfAnHour: TimeSpan.FromSeconds(secondsRoundedToHalfAnHour),
                OffsetRoundedTo15Minutes: TimeSpan.FromSeconds(secondsRoundedTo15Minutes));
        }
    }
}
