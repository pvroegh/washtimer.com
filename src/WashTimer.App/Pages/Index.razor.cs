using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using WashTimer.App.Components;
using WashTimer.App.Shared.ResourceFiles;

namespace WashTimer.App.Pages
{
    public partial class Index
    {
        [Inject]
        private IStringLocalizer<Resources> StringLocalizer { get; set; } = default!;

        private OffsetTimeResult _offsetResult = OffsetTimeResult.Zero;

        private ProgramLength _programLengthReference = default!;
        private TargetTime _targetTimeReference = default!;
        
        public void CalculateAndDisplayOffset()
        {
            _offsetResult = OffsetTimeCalculator.CalculateTimeOffset(
                DateTime.Now,
                _targetTimeReference.Value.TimeOfDay,
                new TimeSpan(_programLengthReference.Hours, _programLengthReference.Minutes, 0));

            StateHasChanged();
        }
    }
}