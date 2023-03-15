using System.Text.Json.Serialization.Metadata;

namespace IsolatedStorage.Core;

public interface IStorageService<T>
{
    Task SaveObject(T obj, string key, JsonTypeInfo<T> typeInfo);
    Task<T?> LoadObject(string key, JsonTypeInfo<T> typeInfo);
}
