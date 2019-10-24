using kpsUowRmqTest.Data.Context;
using kpsUowRmqTest.Data.Interfaces;
using kpsUowRmqTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace kpsUowRmqTest.Service
{
    public class ProductRepository:Repository<Product>, IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext):base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
