using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEntity
{
    public class Details
    {
        public int regid { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user_name { get; set; }
        public string pass_word { get; set; }
        public string phone { get; set; }
        public string division { get; set; }
        public string email { get; set; }


        public int adid { get; set; }
        public Nullable<int> pregid { get; set; }
        public string product_name { get; set; }
        public string product_category { get; set; }
        public string image { get; set; }
        public string product_quantity { get; set; }
        public string price_per_unit { get; set; }
        public string description { get; set; }
        public string pphone { get; set; }
        public string pdivision { get; set; }
    }
}
