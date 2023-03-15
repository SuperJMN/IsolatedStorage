using IsolatedStorage.Core;

namespace IsolatedStorage;

public class IsolatedStorageFactory : IStorageFactory
{
    public IStorageService<T> CreateStorageService<T>() => new IsolatedStorageService<T>();
}
