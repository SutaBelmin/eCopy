using System.Collections.Generic;

namespace eCopy.Services
{
    public interface IService<T, TSearch> where T : class where TSearch : class
    {
        IEnumerable<T> Get(TSearch search = null);

        T GetById(int id);
    }
}
