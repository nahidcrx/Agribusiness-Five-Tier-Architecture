using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEntity;

namespace ProjectInterface
{
   public interface IGenRepo<Gen> where Gen : Entity
    {
        List<Gen> GetAll();
        int insert(Gen g);
        int Update(Gen g);
        int Delete(int id);
    }
}
