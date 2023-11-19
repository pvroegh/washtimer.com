using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

namespace WashTimer.App
{
    public static class HostExtensions
    {
        public static async Task<WebAssemblyHost> AddCulture(this WebAssemblyHost host)
        {
            CultureInfo culture;
            var js = host.Services.GetRequiredService<IJSRuntime>();
            var result = await js.InvokeAsync<string>("blazorCulture.get");

            if (result != null)
            {
                culture = new CultureInfo(result);
            }
            else
            {
                culture = new CultureInfo("en-US");
                await js.InvokeVoidAsync("blazorCulture.set", "en-US");
            }

            Console.WriteLine(culture);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            return host;
        }
    }
}
