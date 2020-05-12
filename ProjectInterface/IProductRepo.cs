using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEntity;

namespace ProjectInterface
{
    public interface IProductRepo: IGenRepo<Product>
    {
        

        //Product Get(int id);
        Details Details(int id);

        Product Get(int id);
    }
}
