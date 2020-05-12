using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectEntity;
using ProjectRepository;
using ProjectInterface;

namespace Project.Controllers
{
    public class RegistrationController : Controller
    {

        

        ICustomerRepo crepo;

        public RegistrationController()
        {
            
        }

        public RegistrationController(ICustomerRepo crepo)
        {
            this.crepo = crepo;
        }

        // GET: Registration
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer c)
        {

            if (ModelState.IsValid)
            {
                crepo.insert(c);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View(c);
            }
        }
    }
}