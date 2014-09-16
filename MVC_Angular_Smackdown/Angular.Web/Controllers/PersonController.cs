using System.Net;
using System.Web.Http;
using Smackdown.Models;
using Smackdown.Repositories;

namespace Angular.Web.Controllers
{
    public class PersonController : ApiController
    {
        private PersonRepository _personRepository = new PersonRepository();

        public IHttpActionResult Get()
        {
            return Ok(_personRepository.Get());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_personRepository.Get(id));
        }

        public IHttpActionResult Post(Person person)
        {
            if (ModelState.IsValid)
            {
                _personRepository.Save(person);
                return Ok(person);
            }
            return StatusCode(HttpStatusCode.NotModified);
        }

        
    }
}
