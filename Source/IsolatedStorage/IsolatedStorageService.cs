using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using IsolatedStorage.Core;

namespace IsolatedStorage;

public class IsolatedStorageService<T> : IStorageService<T>
{
    private static string Identifier { get; } = typeof(T).FullName?.Replace(".", string.Empty) ?? "default";

    public async Task SaveObject(T obj, string key, JsonTypeInfo<T> typeInfo)
    {
        var store = IsolatedStorageFile.GetStore(
            IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, 
            null, null);
        await using var isoStream = new IsolatedStorageFileStream(Identifier + key, FileMode.Create, store);
        await JsonSerializer.SerializeAsync(isoStream, obj, typeInfo);
    }

    public async Task<T?> LoadObject(string key, JsonTypeInfo<T> typeInfo)
    {
        try
        {
            var store = IsolatedStorageFile.GetStore(
                IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, 
                null, null);
            await using var isoStream = new IsolatedStorageFileStream(Identifier + key, FileMode.Open, store);
            var storedObj = await JsonSerializer.DeserializeAsync(isoStream, typeInfo);
            return storedObj ?? default;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
        }

        return default;
    }
}
