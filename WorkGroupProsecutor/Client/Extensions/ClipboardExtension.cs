using Microsoft.JSInterop;

namespace WorkGroupProsecutor.Client.Extensions
{
    public class ClipboardExtension
    {
        private readonly IJSRuntime _jsRuntime;

        public ClipboardExtension(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ValueTask<string> ReadTextAsync()
        {
            return _jsRuntime.InvokeAsync<string>("navigator.clipboard.readText");
        }

        public ValueTask WriteTextAsync(string text)
        {
            return _jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
        }
    }
}
