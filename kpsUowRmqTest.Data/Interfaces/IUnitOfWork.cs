using System;
using System.Collections.Generic;
using System.Text;

namespace kpsUowRmqTest.Data.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        int Complete();
        IProductRepository ProductRepository { get; set; }
        IUserRepository UserRepository { get; set; }
    }
}
