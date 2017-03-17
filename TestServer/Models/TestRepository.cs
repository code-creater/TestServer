using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestServer.Models
{
    public class TestRepository : ITestRepository
    {
        private static ConcurrentDictionary<string, TestClass> _tests = new ConcurrentDictionary<string, TestClass>();

        public TestRepository()
        {
            Add(new TestClass { Key = "1" });
        }

        public void Add(TestClass item)
        {
            item.Key = Guid.NewGuid().ToString();
            _tests[item.Key] = item;
        }

        public TestClass Find(string key)
        {
            TestClass item;
            _tests.TryGetValue(key, out item);
            return item;
        }

        public IEnumerable<TestClass> GetAll()
        {
            return _tests.Values;
        }

        public TestClass Remove(string key)
        {
            TestClass item;
            _tests.TryRemove(key, out item);
            return item;
        }

        public void Update(TestClass item)
        {
            _tests[item.Key] = item;
        }
    }
}
