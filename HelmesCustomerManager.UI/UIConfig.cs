
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace HelmesCustomerManager.UI
{
    internal class UIConfig
    {
        internal static void RegisterBackEndApiClient(WebAssemblyHostBuilder builder)
        {
            var config = builder.Configuration;
            var address = config["BackendApiAddress"] ?? throw new Exception("Missing config key BackendApiAddress");
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(address)
            });
        }
    }
}
