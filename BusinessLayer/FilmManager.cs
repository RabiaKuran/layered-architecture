using DataAccessLayer;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FilmManager
    {
        Repository<Film> repofilm = new Repository<Film>();

        public List<Film> GetAll()
        {
            return repofilm.List();
        }
        public List<Film> GetByName(string p)
        {
            return repofilm.List(x => x.filmIsmi == p);
        }

    }
}
