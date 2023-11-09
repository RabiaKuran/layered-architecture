using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Film
    {
        [Key]
        public int FilmID { get; set; }

        public DateTime vizyonTarihi { get; set; }

        [StringLength(50)]
        public string filmTuru { get; set; }

        [StringLength(50)]
        public string filmIsmi { get; set; }
        public float hIciFiyat { get; set; }
        public float hSonuFiyat { get; set; }

        public int CategoryID { get; set; }
        //Categori sınıfından bir category properti değeri al
        public virtual Category Category { get; set; }
    }
}
