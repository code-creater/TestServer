using System.Collections.Generic;
using TestServer.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestServer.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        public TestController(ITestRepository testItems)
        {
            TestItems = testItems;
        }

        public ITestRepository TestItems { get; set; }

        public IEnumerable<TestClass> GetAll()
        {
            return TestItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTest")]
        public IActionResult GetById(string id)
        {
            var item = TestItems.Find(id);
            if (item == null)
                return NotFound();
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TestClass item)
        {
            if(item == null)
            {
                return BadRequest();
            }
            TestItems.Add(item);
            return CreatedAtRoute("GetTest", new { id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TestClass item)
        {
            if(item == null || item.Key != id)
            {
                return BadRequest();
            }

            var test = TestItems.Find(id);
            if(test == null)
            {
                return NotFound();
            }
            TestItems.Update(item);
            return new NoContentResult();
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] TestClass item, string id)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var test = TestItems.Find(id);
            if (test == null)
            {
                return NotFound();
            }

            item.Key = test.Key;

            TestItems.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id]")]
        public IActionResult Delete(string id)
        {
            var test = TestItems.Find(id);
            if(test == null)
            {
                return NotFound();
            }

            TestItems.Remove(id);
            return new NoContentResult();
        }

        //// GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
