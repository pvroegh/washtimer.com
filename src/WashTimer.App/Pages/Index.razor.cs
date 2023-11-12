using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using WashTimer.App.Shared.ResourceFiles;

namespace WashTimer.App.Pages
{
    public partial class Index
    {
        [Inject]
        private IStringLocalizer<Resources> StringLocalizer { get; set; } = default!;
    }
}