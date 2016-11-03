using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testEF.Data;

namespace testEF
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new NorthwindEntities();
            var cat=db.Categories;
            foreach (var categ in cat)
            {
                Console.WriteLine($"\t{categ.CategoryName} - {categ.Description}");
                Console.WriteLine(string.Join(" ; ", categ.Products.Select(p=>p.ProductName)));
            }

            //db.Categories.First(c => c.CategoryID == 1).Description += "test adition";
            //db.SaveChanges();
        }
    }
}
