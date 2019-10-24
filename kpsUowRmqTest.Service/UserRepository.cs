using kpsUowRmqTest.Data.Context;
using kpsUowRmqTest.Data.Interfaces;
using kpsUowRmqTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace kpsUowRmqTest.Service
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext):base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
