using BusinessLayer;
using BusinessLayer.ValidationRules;
using EntityLayer.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CategoryManager cm = new CategoryManager();
            FilmManager fm = new BusinessLayer.FilmManager();

            foreach (var item in fm.GetAll())
            {
                Console.WriteLine("ID: "+item.FilmID+ 
                     "Film Türü: "+ item.filmTuru + "FilmAdı: "+item.filmIsmi+"Hafta İçi Fiyat: "+item.hIciFiyat + "Hafta Sonu Fiyat: "+item.hSonuFiyat);

            }

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------");

            Console.WriteLine();

            string filmName = "deneme";
            foreach (var item in fm.GetByName(filmName))
            {
                Console.WriteLine("ID: " + item.FilmID +
                     "Film Türü: " + item.filmTuru + "FilmAdı: " + item.filmIsmi + "Hafta İçi Fiyat: " + item.hIciFiyat + "Hafta Sonu Fiyat: " + item.hSonuFiyat);
            }
            Console.WriteLine();

            Category c = new Category();
            c.CategoryName = "test yeni son";
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(c);
            if(results.IsValid)
            {
                cm.BLAdd(c);
                Console.WriteLine("Kategori eklendi");
            }
            else
            {
                foreach(var item in results.Errors) {
                    Console.WriteLine(item.ErrorMessage);
                
                
                }
            }


            cm.BLDelete(8);

            /*Category c = new Category();
            c.CategoryID = 3;
            c.CategoryName = "Aksiyon Güncel";
            cm.BLUpdate(c);

            foreach (var item in cm.GetAll())
            {
                Console.WriteLine("ID: "+ item.CategoryID + " - Kategori Adı: "+item.CategoryName);

            }*/
            //Category ct = new Category();
            //ct.CategoryName = "Halılar";
            //cm.BLAdd(ct);


            Console.Read();

        }
    }
}
