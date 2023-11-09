using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //T'nin anlamı dışarıdan bir tane class gönderileceğinin bildirilmesi
    public interface IRepository<T>
    {
        int Insert(T p);
        int Update(T p);
        int Delete(T p);
        List<T> List();

        T GetById(int id);

        List<T> List(Expression<Func<T,bool>> filter);

        T Find(Expression<Func<T, bool>> where);
    }
}
