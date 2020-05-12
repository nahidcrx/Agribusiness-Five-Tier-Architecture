using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEntity;

namespace ProjectInterface
{
    public interface IProfileRepo: IGenRepo<Product>
    {
        List<Product> GetAll(int id);

        //Product Get(int id);
        //Details Details(int id);
        Customer Get(int id);
        Details getmyinfo(int id);
        List<Product> GetAll(string s);

    }
}
