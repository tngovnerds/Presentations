using System.Linq;
using System.Web.Mvc;
using Smackdown.Models;
using Smackdown.Repositories;

namespace MVC_Angular_Smackdown.Controllers
{
    public class AddressController : Controller
    {
        private PersonRepository personRepository = new PersonRepository();

        // GET: Address
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(int personId)
        {
            ViewBag.PersonId = personId;
            var address = new Address();

            return View(address);
        }

        [HttpPost]
        public ActionResult Create(int personId, Address address)
        {
            if (ModelState.IsValid)
            {
                var person = personRepository.Get(personId);
                personRepository.SaveAddress(personId, address);
                return RedirectToAction("Details", "Home", new{id=personId});
            }
            
            ViewBag.PersonId = personId;
            return View(address);
        }

        [HttpGet]
        public ActionResult Details(int personId, int addressId)
        {
            ViewBag.PersonId = personId;
            var person = personRepository.Get(personId);
            var address = person.Addresses.FirstOrDefault(p => p.Id == addressId);
            return View(address);
        }

        [HttpGet]
        public ActionResult Edit(int personId, int addressId)
        {
            ViewBag.PersonId = personId;
            var person = personRepository.Get(personId);
            var address = person.Addresses.FirstOrDefault(p => p.Id == addressId);
            return View(address);
        }
        
        [HttpPost]
        public ActionResult Edit(int personId, Address address)
        {
            if (ModelState.IsValid)
            {
                var person = personRepository.Get(personId);
                personRepository.SaveAddress(personId, address);
                return RedirectToAction("Details", "Home", new { id = personId });
            }

            ViewBag.PersonId = personId;
            return View(address);
        }


    }
}