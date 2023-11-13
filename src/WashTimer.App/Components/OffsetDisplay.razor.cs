using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using WashTimer.App.Shared.ResourceFiles;

namespace WashTimer.App.Components
{
    public partial class OffsetDisplay
    {
        [Inject]
        public IStringLocalizer<Resources> StringLocalizer { get; set; } = default!;

        [Parameter]
        public TimeSpan Offset { get; set; }
    }
}