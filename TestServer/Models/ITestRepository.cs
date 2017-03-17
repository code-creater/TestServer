using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestServer.Models
{
    public interface ITestRepository
    {
        void Add(TestClass item);
        IEnumerable<TestClass> GetAll();
        TestClass Find(string key);
        TestClass Remove(string key);
        void Update(TestClass item);
    }
}
