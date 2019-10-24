using System;
using System.Collections.Generic;
using System.Text;

namespace kpsUowRmqTest.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Year { get; set; }
        public long TCKN { get; set; }
    }
}
