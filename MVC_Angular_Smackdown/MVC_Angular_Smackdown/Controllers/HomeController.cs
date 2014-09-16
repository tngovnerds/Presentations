using System.Web.Mvc;
using Smackdown.Models;
using Smackdown.Repositories;

namespace MVC_Angular_Smackdown.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonRepository _personRepository = new PersonRepository();
        // GET: Home
        public ActionResult Index()
        {
            var people = _personRepository.Get();
            return View(people);
        }

        [HttpGet]
        public ActionResult Create()      
        {
            var person = new Person();
            return View(person);
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (!ModelState.IsValid) return View(person);

            _personRepository.Save(person);
            return RedirectToAction("Details", new {id = person.Id });
       
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_personRepository.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (!ModelState.IsValid) return View(person);

            _personRepository.Save(person);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_personRepository.Get(id));
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}