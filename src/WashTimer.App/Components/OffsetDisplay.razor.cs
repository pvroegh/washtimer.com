using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using WashTimer.App.Shared.ResourceFiles;

namespace WashTimer.App.Components
{
    public partial class OffsetDisplay
    {
        public enum RoundingMode
        {
            FifteenMinutes,
            ThirtyMinutes,
            SixtyMinutes
        }

        [Inject]
        public IStringLocalizer<Resources> StringLocalizer { get; set; } = default!;

        [Parameter]
        public OffsetTimeResult Offset { get; set; } = OffsetTimeResult.Zero;

        public TimeSpan RoundedOffset => Rounding switch
        {
            RoundingMode.FifteenMinutes => Offset.OffsetRoundedTo15Minutes,
            RoundingMode.ThirtyMinutes => Offset.OffsetRoundedToHalfAnHour,
            RoundingMode.SixtyMinutes => Offset.OffsetRoundedToOneHour
        };

        [Parameter]
        public RoundingMode Rounding { get; set; } = RoundingMode.FifteenMinutes;

        protected void OnFifteenMinutesRoundingClick()
        {
            Rounding = RoundingMode.FifteenMinutes;
        }
        protected void OnThirtyMinutesRoundingClick()
        {
            Rounding = RoundingMode.ThirtyMinutes;
        }
        protected void OnSixtyMinutesRoundingClick()
        {
            Rounding = RoundingMode.SixtyMinutes;
        }
    }
}