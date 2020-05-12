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
   public class ProfileRepo : GenRepo<Product>, IProfileRepo
    {

        mydbContext context = new mydbContext();
        public ProfileRepo(mydbContext context)
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

      

        
 

        public Details getmyinfo(int id) {

            Customer c = context.Customers.SingleOrDefault(i => i.regid == id);
            Details d = new Details()
            {

                first_name = c.first_name,
                last_name = c.last_name,
                user_name = c.user_name,
                phone = c.phone,
                division = c.division,
                email=c.email


            };

            return d;

        }

        public new Customer Get(int id)
        {
            return context.Customers.SingleOrDefault(i=>i.regid == id);
        }


        public List<Product> GetAll(String s)
        {
           
            var pro = from m in context.Products
                      select m;

            var pro2 = from n in context.Products
                      select n;

           // List<Product> em = new List<Product>();


       

                pro = pro.Where(m => m.pdivision.Contains(s));
                pro2 = pro2.Where(n => n.product_category.Contains(s));

            var p = pro.ToList();
            var q = pro2.ToList();
                
                 if(!p.Any())
                {
                return q;
                }
                else
                {
                return p;
                }     
           
          
        }

       


    }
}
