using System.Net;
using System.Net.Http;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MessagingService.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        // GET: api/values
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        // GET api/values/5

        //[HttpGet("{username}")]
        //public string Get(string username)
        //{
        //    var x = new List<Contact>()
        //    {
                
        //    };

        //        return new JsonResult();



        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string myUsername, [FromBody] string hisUsername)
        {
          
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
