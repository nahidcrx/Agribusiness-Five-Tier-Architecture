using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectEntity;
using ProjectRepository;
using ProjectData;
using ProjectInterface;

namespace Project.Controllers
{
    public class AdminController : BaseController
    {
        
        IAdminRepo arepo;
        IProductRepo prepo;
        ICustomerRepo crepo;
       
        mydbContext context = new mydbContext();

        

        public AdminController(IAdminRepo arepo,IProductRepo prepo,ICustomerRepo crepo)
        {
            this.arepo = arepo;
            this.prepo = prepo;
            this.crepo = crepo;
        }
        // GET: Admin

      
        public ActionResult Index()
        {
            if (Session["vid"].ToString() == "101") {
                return View(crepo.GetAll());
            }
            else
                return RedirectToAction("Index","Index");
        }
        public ActionResult Details(int id)
        {
            if (Session["vid"].ToString() == "101")
            {
                Customer c = context.Customers.SingleOrDefault(i => i.regid == id);
                ViewData["first_name"] = c.first_name;
                ViewData["last_name"] = c.last_name;
                ViewData["user_name"] = c.user_name;
                ViewData["phone"] = c.phone;
                return View(arepo.GetAll(id));
            }
            else
                return RedirectToAction("Index","Index");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["vid"].ToString() == "101")
            {
                Product p = arepo.Get(id);
                return View(p);
            }
            else
                return RedirectToAction("Index","Index");

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Confirmed(int id)
        {
            if (Session["vid"].ToString() == "101")
            {
                Product ppp = context.Products.SingleOrDefault(i => i.adid == id);
                Product pp = arepo.Get(id);
                prepo.Delete(pp.adid);
                return RedirectToAction("Details", new { id = ppp.pregid });
            }
            else
                return RedirectToAction("Index", "Index");


        }


        [HttpPost]
        public ActionResult Index(FormCollection product)
        {
            if (Session["vid"].ToString() == "101")
            {
                string s = Request["search"];

                return View(arepo.GetAll(s));
            }
            else
                return RedirectToAction("Index","Index");

        }


        public ActionResult Report()
        {
            
                return View();
            
        }

        public ActionResult UserDivision()
        {

            var query = context.Customers
             .GroupBy(p => p.division)
             .Select(g => new Report { name = g.Key, count = g.Count() }).ToList();

            return View(query);

        }

        public ActionResult ProductDivision()
        {

            var query = context.Products
             .GroupBy(p => p.pdivision)
             .Select(g => new Report { name = g.Key, count = g.Count() }).ToList();

            return View(query);

        }
    }
}