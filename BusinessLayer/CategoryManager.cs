using DataAccessLayer;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    //BusinessLayer: Crud işlemleri gerçekleştirilmeden önce süzgeç olarak kullanılan katman.
    //Örneğin bir ekleme işlemi yapacaksak bu şartlar sağlanıyor mu? ya da listeleme yapacaksak bu kişinin listelemeye yetkisi var mı?
    //silme işlemi yapınca vt'nı bozulacak mı gibi filtreleme işlemleri yapar
    public class CategoryManager
    {
        Repository<Category> caterepo = new Repository<Category>();
   
        public List<Category> GetAll()
        {
            return caterepo.List();
        }

        public int BLAdd(Category c)
        {
            if(c.CategoryName.Length <= 3 )
            {
                return -1;
            }return caterepo.Insert(c);
        }

        public int BLDelete(int p)
        {
            if(p != 0)
            {
                Category c = caterepo.Find(x => x.CategoryID == p);
                return caterepo.Delete(c);
            
            
            } else { return -1; }
        }

        public int BLUpdate(Category p)
        {
            if(p.CategoryName=="" || p.CategoryName.Length<=3 || p.CategoryName.Length>=30 )
            {
                return -1;

            }
            else
            {
                Category ct = caterepo.Find(x=>x.CategoryID == p.CategoryID);
                ct.CategoryName = p.CategoryName;
                return caterepo.Update(ct);
            }
        }


    
    }
}
