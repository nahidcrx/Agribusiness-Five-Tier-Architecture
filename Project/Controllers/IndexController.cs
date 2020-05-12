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
    public class IndexController : Controller
    {
        // GET: Index
        
        IProductRepo prepo;

        

        


        public IndexController(IProductRepo prepo)
        {
            this.prepo = prepo;
        }
        // GET: Product

        [HttpGet]
        public ActionResult Index()
        {
             return View(prepo.GetAll());
            //return View();
        }
    }
}