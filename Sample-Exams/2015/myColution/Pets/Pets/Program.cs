using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new PetsExam2015DbContext();
            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;
            var start = DateTime.Now;
            var generator = new SampleDataGenerator(db);
            generator.SeedData();
            Console.WriteLine(DateTime.Now - start);
            db.Species.OrderBy(s => s.Products.Count).Select(s => s.Name + ": " + s.Products.Count).ToList().ForEach(Console.WriteLine);


        }
    }
}
