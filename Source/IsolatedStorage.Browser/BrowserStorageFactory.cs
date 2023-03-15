using IsolatedStorage.Core;

namespace IsolatedStorage.Browser;

public class BrowserStorageFactory : IStorageFactory
{
    public IStorageService<T> CreateStorageService<T>() => new BrowserStorageService<T>();
}
