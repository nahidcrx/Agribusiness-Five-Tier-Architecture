using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectData;
using ProjectInterface;
using ProjectEntity;

namespace ProjectRepository
{
    public class GenRepo<Gen> : IGenRepo<Gen> where Gen : Entity
    {
        //Temporary
        mydbContext context;

        public mydbContext Context
        {
            get { return context; }
        }

        public GenRepo(mydbContext context)
        {
            this.context = context;
        }

        public List<Gen> GetAll()
        {
            return Context.Set<Gen>().ToList();
        }

        public Gen Get(int id)
        {
            return Context.Set<Gen>().Find(id);
        }

        public int insert(Gen g)
        {
            Context.Set<Gen>().Add(g);
            return Context.SaveChanges();
        }

        public int Update(Gen g)
        {
            Context.Entry<Gen>(g).State = System.Data.Entity.EntityState.Modified;
            return Context.SaveChanges();
        }

        public int Delete(int id)
        {
            //Context.Set<Gen>().Remove(g);
            Gen model = context.Set<Gen>().Find(id);
            context.Set<Gen>().Remove(model);
            return Context.SaveChanges();
        }
    }
}

