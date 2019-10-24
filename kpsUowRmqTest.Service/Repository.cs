using kpsUowRmqTest.Data.Context;
using kpsUowRmqTest.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kpsUowRmqTest.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _repository;
        public Repository(DataContext dataContext)
        {
            _repository = dataContext.Set<T>();
        }
        public bool Delete(int id)
        {
            bool result = false;
            T model = Find(id);
            if(model!=null)
            {
                _repository.Remove(model);
                result = true;
            }

            return result;
        }

        public T Find(int id)
        {
            return _repository.Find(id);
        }

        public IEnumerable<T> Get()
        {
            return _repository.ToList();
        }

        public T Insert(T model)
        {
            _repository.Add(model);
            return model;
        }

        public T Update(T model)
        {
            _repository.Update(model);
            return model;
        }
    }
}
