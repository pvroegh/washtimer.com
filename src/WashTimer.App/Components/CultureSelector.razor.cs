using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace WashTimer.App.Components
{
    public partial class CultureSelector
    {
        [Inject]
        private NavigationManager Navigation { get; set; } = default!;

        [Inject]
        private IJSRuntime JsRuntime { get; set; } = default!;

        private CultureInfo[] supportedCultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("nl-NL"),
        };

        private CultureInfo Culture
        {
            get => CultureInfo.CurrentCulture;
            set
            {
                if (CultureInfo.CurrentCulture != value)
                {
                    var js = (IJSInProcessRuntime)JsRuntime;
                    js.InvokeVoid("blazorCulture.set", value.Name);

                    Navigation.NavigateTo(Navigation.Uri, forceLoad: true);
                }
            }
        }
    }
}