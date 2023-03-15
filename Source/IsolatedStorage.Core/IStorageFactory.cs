namespace IsolatedStorage.Core;

public interface IStorageFactory
{
    IStorageService<T> CreateStorageService<T>();
}
