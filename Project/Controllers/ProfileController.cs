using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectRepository;
using ProjectEntity;
using ProjectData;
using ProjectInterface;

namespace Project.Controllers
{
    public class ProfileController : BaseController
    {
        // GET: Profile
        mydbContext context = new mydbContext();
        ICustomerRepo crepo;
        IProductRepo prepo;
        IProfileRepo prorepo;

        public ProfileController()
        {
            
        }

        public ProfileController(IProfileRepo prorepo,ICustomerRepo crepo,IProductRepo prepo)
        {
            this.prorepo = prorepo;
            this.crepo = crepo;
            this.prepo = prepo;
        }

        public ActionResult Index(int id)
        {
            if (Session["vid"].ToString() == "103")
            {
                Customer c = context.Customers.SingleOrDefault(i => i.regid == id);
                ViewData["first_name"] = c.first_name;
                ViewData["last_name"] = c.last_name;
                return View(prorepo.GetAll(id));
            }
            else
                return RedirectToAction("Index", "Index");
        }

        [HttpGet]
        public ActionResult AdPost()
        {
            if (Session["vid"].ToString() == "103")
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Index");
        }

        [HttpPost]
        public ActionResult AdPost(Product p)
        {
            if (Session["vid"].ToString() == "103")
            {
                if (ModelState.IsValid)
                {
                    prorepo.insert(p);
                    return RedirectToAction("Index", new { id = Session["regid"] });
                }
                else
                {
                    return View(p);
                }
            }
            else
                return RedirectToAction("Index", "Index");
        }

        [HttpGet]
        public ActionResult Myinfo(int id)
        {
            if (Session["vid"].ToString() == "103")
            {
                return View(prorepo.getmyinfo(id));
            }
            else
                return RedirectToAction("Index", "Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["vid"].ToString() == "103")
            {
                Customer nc = prorepo.Get(id);
                return View(nc);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        [HttpPost]
        public ActionResult Edit(Customer nc)
        {

            
                if (Session["vid"].ToString() == "103")
                {
                if (ModelState.IsValid)
                {
                    crepo.Update(nc);
                    return RedirectToAction("Myinfo", new { id = Session["regid"] });
                }
                else { return View(nc); }
                }
                else
                    return RedirectToAction("Index", "Index");
            

            /* if (ModelState.IsValid)
             {
                 pro.Update(nc);
                 return RedirectToAction("Myinfo", new { id = Session["regid"] });
             }

             else
             {
                 return View(nc);
             }*/



        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["vid"].ToString() == "103")
            {
                Product p = prepo.Get(id);
                return View(p);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        [HttpPost][ActionName("Delete")]
        public ActionResult Delete_Confirmed(int id)
        {
            if (Session["vid"].ToString() == "103")
            {
                Product pp = prepo.Get(id);
                prepo.Delete(pp.adid);
                return RedirectToAction("Index", new { id = Session["regid"] });
            }
            else
                return RedirectToAction("Index", "Index");


        }





        [HttpGet]
        public ActionResult PEdit(int id)
        {
            if (Session["vid"].ToString() == "103")
            {
                Product nc = prepo.Get(id);
                return View(nc);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        [HttpPost]
        public ActionResult PEdit(Product nc)
        {


            if (Session["vid"].ToString() == "103")
            {
                if (ModelState.IsValid)
                {
                    prepo.Update(nc);
                    return RedirectToAction("/../Profile/Index", new { id = Session["regid"] });
                }
                else { return View(nc); }
            }
            else
                return RedirectToAction("Index", "Index");


            /* if (ModelState.IsValid)
             {
                 pro.Update(nc);
                 return RedirectToAction("Myinfo", new { id = Session["regid"] });
             }

             else
             {
                 return View(nc);
             }*/



        }


    }
}