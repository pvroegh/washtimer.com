using WashTimer.App;

namespace WashTime.App.Tests
{
    public class OffsetTimeCalculatorTests
    {
        [Theory]
        [MemberData(nameof(OffsetTimeCalculatorTestsClassData.Data), MemberType = typeof(OffsetTimeCalculatorTestsClassData))]
		public void CalculateTimeOffset_Scenario_ExpectedBehavior(DateTime now, TimeSpan targetTime, TimeSpan programLength, TimeSpan expectedOffsetRoundedToOneHour, TimeSpan expectedOffsetRoundedToHalfAnHour, TimeSpan expectedOffsetRoundedTo15Minutes)
		{
			// Arrange & Act
			var result = OffsetTimeCalculator.CalculateTimeOffset(now, targetTime, programLength);

			// Assert
			result.OffsetRoundedTo15Minutes.Should().Be(expectedOffsetRoundedTo15Minutes);
            result.OffsetRoundedToHalfAnHour.Should().Be(expectedOffsetRoundedToHalfAnHour);
            result.OffsetRoundedToOneHour.Should().Be(expectedOffsetRoundedToOneHour);
        }

		private class OffsetTimeCalculatorTestsClassData
		{
			private record TestCaseData(DateTime Now, TimeSpan TargetTime, TimeSpan ProgramLength, TimeSpan ExpectedOffsetRoundedToOneHour, TimeSpan ExpectedOffsetRoundedToHalfAnHour, TimeSpan ExpectedOffsetRoundedTo15Minutes)
			{
				public object[] Deconstruct()
				{
					return new object[]
					{
						Now, TargetTime, ProgramLength, ExpectedOffsetRoundedToOneHour, ExpectedOffsetRoundedToHalfAnHour, ExpectedOffsetRoundedTo15Minutes
					};
				}
			}

			public static IEnumerable<object[]> Data => _testCaseData.Select(x => x.Deconstruct());

			private static readonly TestCaseData[] _testCaseData = new TestCaseData[]
			{
				// All 0's
				new TestCaseData(
                    Now: new DateTime(2023, 1, 1, 0, 0, 0),
                    TargetTime:  TimeSpan.Zero,
                    ProgramLength: TimeSpan.Zero,
                    ExpectedOffsetRoundedToOneHour: TimeSpan.FromDays(1),
                    ExpectedOffsetRoundedToHalfAnHour: TimeSpan.FromDays(1),
                    ExpectedOffsetRoundedTo15Minutes: TimeSpan.FromDays(1)),
				// 15 minute program length
				new TestCaseData(
                    Now: new DateTime(2023, 1, 1, 0, 0, 0),
                    TargetTime:  TimeSpan.Zero,
                    ProgramLength: TimeSpan.FromMinutes(15),
                    ExpectedOffsetRoundedToOneHour: new TimeSpan(23, 0, 0),
                    ExpectedOffsetRoundedToHalfAnHour: new TimeSpan(23, 30, 0),
                    ExpectedOffsetRoundedTo15Minutes: new TimeSpan(23, 45, 0)),
				// 30 minute program length
				new TestCaseData(
                    Now: new DateTime(2023, 1, 1, 0, 0, 0),
                    TargetTime:  TimeSpan.Zero,
                    ProgramLength: TimeSpan.FromMinutes(30),
                    ExpectedOffsetRoundedToOneHour: new TimeSpan(23, 0, 0),
                    ExpectedOffsetRoundedToHalfAnHour: new TimeSpan(23, 30, 0),
                    ExpectedOffsetRoundedTo15Minutes: new TimeSpan(23, 30, 0)),
				//// 45 minute program length
				new TestCaseData(
                    Now: new DateTime(2023, 1, 1, 0, 0, 0),
                    TargetTime:  TimeSpan.Zero,
                    ProgramLength: TimeSpan.FromMinutes(45),
                    ExpectedOffsetRoundedToOneHour: new TimeSpan(23, 0, 0),
                    ExpectedOffsetRoundedToHalfAnHour: new TimeSpan(23, 00, 0),
                    ExpectedOffsetRoundedTo15Minutes: new TimeSpan(23, 15, 0)),
                // 2:30 program length, crossing a day
                new TestCaseData(
                    Now: new DateTime(2023, 1, 1, 23, 0, 0),
                    TargetTime: TimeSpan.Parse("7:00"),
                    ProgramLength: TimeSpan.Parse("2:30"),
                    ExpectedOffsetRoundedToOneHour: new TimeSpan(5, 0, 0),
                    ExpectedOffsetRoundedToHalfAnHour: new TimeSpan(5, 30, 0),
                    ExpectedOffsetRoundedTo15Minutes: new TimeSpan(5, 30, 0)),
				//// 2:30 program length, hitting exactly at midnight
				new TestCaseData(
                    Now: new DateTime(2023, 1, 1, 21, 30, 0),
                    TargetTime: TimeSpan.Parse("0:00"),
                    ProgramLength: TimeSpan.Parse("2:30"),
                    ExpectedOffsetRoundedToOneHour: TimeSpan.Zero,
                    ExpectedOffsetRoundedToHalfAnHour: TimeSpan.Zero,
                    ExpectedOffsetRoundedTo15Minutes: TimeSpan.Zero),
                // 2:30 program length, not making target time
                new TestCaseData(
                    Now: new DateTime(2023, 1, 1, 22, 30, 0),
                    TargetTime: TimeSpan.Parse("0:00"),
                    ProgramLength: TimeSpan.Parse("2:30"),
                    ExpectedOffsetRoundedToOneHour: TimeSpan.Zero,
                    ExpectedOffsetRoundedToHalfAnHour: TimeSpan.Zero,
                    ExpectedOffsetRoundedTo15Minutes: TimeSpan.Zero),
            };
		}
	}
}
