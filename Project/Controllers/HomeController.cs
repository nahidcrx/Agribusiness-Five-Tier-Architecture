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
    public class HomeController : BaseController
    {
    
        IProductRepo prepo;
        IProfileRepo urepo;

        

        public HomeController(IProductRepo prepo, IProfileRepo urepo)
        {
            this.prepo = prepo;
            this.urepo = urepo;
        }

        
        // GET: Product

       [HttpGet]
        public ActionResult Index()
        {
            if (Session["vid"].ToString() == "103")
            {
                return View(prepo.GetAll());
            }
            else
                return RedirectToAction("Index","Index");
        }

        
        public ActionResult Details(int id)
        {
            if (Session["vid"].ToString() == "103")
            {
                return View(prepo.Details(id));
            }
            else
                return RedirectToAction("Index","Index");
        }

        [HttpPost]
        public ActionResult Index(FormCollection product)
        {
            if (Session["vid"].ToString() == "103")
            {
                string s = Request["search"];

                return View(urepo.GetAll(s));
            }
            else
                return RedirectToAction("Index", "Index");

        }


        public ActionResult Chat()
        {

            return View();
        }



    }
}