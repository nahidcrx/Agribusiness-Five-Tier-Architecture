using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEntity;

namespace ProjectInterface
{
    public interface IAdminRepo: IGenRepo<Admin>
    {
        List<Customer> GetAll(string s);
        List<Product> GetAll(int id);
        Product Get(int id);




    }
}
