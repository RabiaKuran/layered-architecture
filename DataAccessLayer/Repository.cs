using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    //by generic repository
    public class Repository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        //ctor 
        public Repository()
        {
            _object = c.Set<T>();
        }
        public int Delete(T p)
        {
            //_object.Remove(p);
            //return c.SaveChanges();
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            return c.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _object.FirstOrDefault(where);
        }

        public T GetById(int id)
        {
            return _object.Find(id);   
        }

        public int Insert(T p)
        {
            var addedentity = c.Entry(p);
            addedentity.State = EntityState.Added;
            //_object.Add(p);
            return c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public int Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            return c.SaveChanges();
        }
    }
}
