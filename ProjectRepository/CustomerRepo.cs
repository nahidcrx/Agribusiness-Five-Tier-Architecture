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
    public class CustomerRepo: GenRepo<Customer>,ICustomerRepo
    {

        public CustomerRepo(mydbContext context)
            : base(context)
        { }


    }
}
