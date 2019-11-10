using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinPhonebook.Services.Abstact
{
    public interface IDataStorage<T>
    {
        bool IsLoaded { get; }
        Task LoadAsync(int count);
        Task<List<T>> GetAsync(int count, string search = default);
    }
}