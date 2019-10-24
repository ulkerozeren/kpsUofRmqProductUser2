using kpsUowRmqTest.Data.Context;
using kpsUowRmqTest.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace kpsUowRmqTest.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            ProductRepository = new ProductRepository(dataContext);
            UserRepository = new UserRepository(dataContext);
        }
        public IProductRepository ProductRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        public int Complete()
        {
            return _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
