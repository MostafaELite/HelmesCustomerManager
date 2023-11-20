using HelmesCustomerManager.Domain.Entities;
using System.Text.Json;

namespace HelmesCustomerManager.UI
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<TModel> ParseResponseAsync<TModel>(this HttpResponseMessage response)
        {
            var parsedResponse = await response.Content.ReadAsStringAsync();
            
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var model = JsonSerializer.Deserialize<TModel>(parsedResponse, option);
            return model;
        }
    }
}
