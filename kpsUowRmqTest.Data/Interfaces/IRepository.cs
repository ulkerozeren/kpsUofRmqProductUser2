using System;
using System.Collections.Generic;
using System.Text;

namespace kpsUowRmqTest.Data.Interfaces
{
    public interface IRepository<T> where T:class
    {
        T Find(int id);
        IEnumerable<T> Get();
        T Insert(T model);
        T Update(T model);
        bool Delete(int id);
    }
}
