using Microsoft.JSInterop;
namespace ServiceProvider.Client.Pages.Services
{
    public class MyServices
    {
        public static async Task ShowDescription(IJSRuntime js, string? description)
        {
            await js.InvokeVoidAsync("alert", $"Description: {description}");
        }

        public static async Task ShowMsg(IJSRuntime js, string? description)
        {
            await js.InvokeVoidAsync("alert", $"{description}");
        }
    }

}

