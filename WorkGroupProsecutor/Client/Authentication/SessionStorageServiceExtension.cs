using Blazored.SessionStorage;
using System.Text.Json;
using System.Text;

namespace WorkGroupProsecutor.Client.Authentication
{
    public static class SessionStorageServiceExtension
    {
        public static async Task SaveItemEncryptedAsync<T>(this ISessionStorageService sessionStorService, string key, T item)
        {
            var itemJson = JsonSerializer.Serialize(item);
            var itemJsonBytes = Encoding.UTF8.GetBytes(itemJson);
            var base64Json = Convert.ToBase64String(itemJsonBytes);
            await sessionStorService.SetItemAsync(key, base64Json);
        }

        public static async Task<T> ReadEncryptedItemAsync<T>(this ISessionStorageService sessionStorService, string key)
        {
            var base64Json = await sessionStorService.GetItemAsync<string>(key);
            var itemJsonBytes = Convert.FromBase64String(base64Json);
            var itemJson = Encoding.UTF8.GetString(itemJsonBytes);
            var item = JsonSerializer.Deserialize<T>(itemJson);
            return item;
        }
    }
}
