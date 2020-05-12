using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectEntity;
using ProjectRepository;
using ProjectData;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        mydbContext context = new mydbContext();
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection user)
        {
            string Name = Request["uname"].ToString();
            string Pass = Request["pass"].ToString();
            Customer customer = context.Customers.SingleOrDefault(u => u.user_name == Name && u.pass_word == Pass);
            Admin admin = context.Admins.SingleOrDefault(u => u.user_name == Name && u.pass_word == Pass);

            if (customer==null && admin==null)
            {
                TempData["error"] = "Invalid User or Password";
                return RedirectToAction("Index");
            }
            else
            {
                if(customer==null)
                {
                    Session["user_name"] = admin.user_name;
                    
                    Session["type"] = admin.admin_type;
                    if (admin.admin_type.Equals("admin"))
                    {
                        Session["vid"] = "101";
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        Session["vid"] = "102";
                        return RedirectToAction("Index", "SuperAdmin");
                    }

                }
                else
                {
                    Session["user_name"] = customer.user_name;
                    Session["regid"] = customer.regid;
                    Session["vid"] = "103";
                   
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult Logout()
        {
            Session["user_name"] = null;
            Session["regid"] = null;
            Session["type"] = null;
            return RedirectToAction("Index");

        }


    }
}