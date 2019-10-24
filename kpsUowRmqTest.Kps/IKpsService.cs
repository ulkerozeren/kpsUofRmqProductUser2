using kpsUowRmqTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kpsUowRmqTest.Kps
{
    public interface IKpsService
    {
        Task<bool> Validate(User user);
    }
}
