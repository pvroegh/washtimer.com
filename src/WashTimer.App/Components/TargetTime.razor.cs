using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using WashTimer.App.Shared.ResourceFiles;

namespace WashTimer.App.Components
{
    public partial class TargetTime
    {
        private DateTime _value;

        [Inject]
        public IStringLocalizer<Resources> StringLocalizer { get; set; } = default!;

        [Parameter]
        public EventCallback ValueChanged { get; set; }

        [Parameter]
        public DateTime Value 
        {
            get => _value;
            set
            {
                if (value == _value)
                    return;

                _value = value;
                if (ValueChanged.HasDelegate)
                {
                    ValueChanged.InvokeAsync();
                }
            }
        }
    }
}