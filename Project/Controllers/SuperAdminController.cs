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
    public class SuperAdminController : BaseController
    {
        
        IAdminRepo arepo;

        public SuperAdminController()
        {
            

        }

        public SuperAdminController(IAdminRepo arepo)
        {
            this.arepo = arepo;

        }
        // GET: SuperAdmin
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["vid"].ToString() == "102")
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Index");
        }

        [HttpPost]
        public ActionResult Index(Admin a)
        {
            if (Session["vid"].ToString() == "102")
            {

                if (ModelState.IsValid)
                {
                    arepo.insert(a);
                    return RedirectToAction("Index", "SuperAdmin");
                }
                else
                {
                    return View(a);
                }
            }
            else
                return RedirectToAction("Index", "Index");
        }

        

    }
}