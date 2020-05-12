using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEntity;
using ProjectData;
using ProjectInterface;

namespace ProjectRepository
{
    public class AdminRepo :  GenRepo<Admin>, IAdminRepo
    {
        mydbContext context = new mydbContext();
        public AdminRepo(mydbContext context)
            : base(context)
        { }
        public List<Product> GetAll(int id)
        {
            string nid = id.ToString();
            var pro = from m in context.Products
                      select m;

            if (!String.IsNullOrEmpty(nid))
            {

                pro = pro.Where(m => m.pregid.ToString().Contains(nid));

            }
            return pro.ToList();
        }




        public new Product Get(int id)
        {
            return context.Products.SingleOrDefault(i => i.adid == id);
        }


        public List<Customer> GetAll(string s)
        {

            var pro = from m in context.Customers
                      select m;

            // List<Product> em = new List<Product>();




            pro = pro.Where(m => m.phone.Contains(s));


            var p = pro.ToList();
 


                return p;
           

        }



    }
}
