using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using WashTimer.App.Shared.ResourceFiles;
using Timer = System.Timers.Timer;

namespace WashTimer.App.Components
{
    public partial class CurrentTime
    {
        [Inject]
        public IStringLocalizer<Resources> StringLocalizer { get; set; } = default!;

        public DateTime CurrentTimeOfDay { get; set; } = DateTime.Now;

        private Timer _timer = default!;

        protected override void OnInitialized()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += Timer_Elapsed;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            CurrentTimeOfDay = DateTime.Now;
            StateHasChanged();
        }
    }
}