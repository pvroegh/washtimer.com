using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using WashTimer.App.Shared.ResourceFiles;

namespace WashTimer.App.Components
{
    public partial class ProgramLength
    {
        [Inject]
        public IStringLocalizer<Resources> StringLocalizer { get; set; } = default!;

        [Parameter]
        public int Hours { get; set; } = 2;
        
        [Parameter]
        public int Minutes { get; set; } = 30;

        [Parameter]
        public EventCallback ValueChanged { get; set; }
    }
}