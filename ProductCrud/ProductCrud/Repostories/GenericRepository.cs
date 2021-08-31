using ProductCrud.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCrud.Repostories
{
    public class GenericRepository<T> where T : class, new()
    {
        ProjectDBContext context = new ProjectDBContext();
        public List<T> TGetList()
        {
            return context.Set<T>().ToList();

        }
        public void TAdd(T p)
        {
            context.Set<T>().Add(p);
            context.SaveChanges();

        }
        public void TDelete(T p)
        {
            context.Set<T>().Remove(p);
            context.SaveChanges();

        }
        public void TUpdate(T p)
        {
            context.Set<T>().Update(p);
            context.SaveChanges();

        }
        public T TgetItemByID(int key)
        {

            return context.Set<T>().Find(key);

        }
        //public List[T] Tliddst(string key)
        //{
        //   return context.Set<T>().Include(key).ToList();


        //}
    }
}
