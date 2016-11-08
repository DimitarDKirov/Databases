using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets
{
    public class SampleDataGenerator
    {
        private PetsExam2015DbContext context;
        private RandomProvider random;
        public SampleDataGenerator(PetsExam2015DbContext context)
        {
            this.context = context;
            this.random = new RandomProvider();
        }

        public void SeedData()
        {
            this.Countries();
            this.Categories();
            this.Species();
            this.Pets();
            this.Products();
        }

        private void Countries()
        {
            Console.WriteLine("Seed countries begin");
            context.OriginCountries.Add(new OriginCountry() { Name = "Bulgaria" });
            context.OriginCountries.Add(new OriginCountry() { Name = "France" });
            context.OriginCountries.Add(new OriginCountry() { Name = "Germany" });
            context.OriginCountries.Add(new OriginCountry() { Name = "Great Britain" });
            context.OriginCountries.Add(new OriginCountry() { Name = "Hungary" });
            context.OriginCountries.Add(new OriginCountry() { Name = "Sweden" });
            context.OriginCountries.Add(new OriginCountry() { Name = "Finland" });
            context.OriginCountries.Add(new OriginCountry() { Name = "Portugal" });
            context.OriginCountries.Add(new OriginCountry() { Name = "Denmark" });
            context.OriginCountries.Add(new OriginCountry() { Name = "Poland" });
            context.OriginCountries.Add(new OriginCountry() { Name = "Slovakia" });
            context.OriginCountries.Add(new OriginCountry() { Name = "China" });
            context.OriginCountries.Add(new OriginCountry() { Name = "Canada" });
            context.OriginCountries.Add(new OriginCountry() { Name = "India" });
            context.OriginCountries.Add(new OriginCountry() { Name = "Brasil" });
            context.OriginCountries.Add(new OriginCountry() { Name = "Russia" });
            context.OriginCountries.Add(new OriginCountry() { Name = "Japan" });
            context.OriginCountries.Add(new OriginCountry() { Name = "Romania" });
            context.OriginCountries.Add(new OriginCountry() { Name = "Ireland" });

            context.SaveChanges();
            Console.WriteLine("Seed countries finished");
        }

        private void Categories()
        {
            Console.WriteLine("Seed categories begin");
            for (int i = 0; i < 50; i++)
            {
                var category = new Category() { Name = "Category " + i + this.random.RandomString(this.random.RandomInt(1, 9)) };
                this.context.Categories.Add(category);
            }

            this.context.SaveChanges();
            Console.WriteLine("Seed categories finished");
        }

        private void Species()
        {
            string[] types = { "Cat", "Dog", "Bird" };
            var countries = this.context.OriginCountries.ToList();
            Console.WriteLine("Seed species begin");

            for (int i = 0; i < 100; i++)
            {
                var specie = new Species()
                {
                    Name = types[i % 3] + ' ' + this.random.RandomString(this.random.RandomInt(1, 14)),
                    OriginCountry = countries[this.random.RandomInt(0, countries.Count - 1)]
                };

                this.context.Species.Add(specie);
            }

            this.context.SaveChanges();

            Console.WriteLine("Seed species finished");
        }

        private void Pets()
        {
            Console.WriteLine("Seed pets begin");
            var species = this.context.Species.ToList();
            var colors = this.context.Colors.ToList();
            var minDate = new DateTime(1990, 1, 1);
            var maxDate = DateTime.Now.AddDays(-60);
            for (int i = 0; i < species.Count; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    var pet = new Pet()
                    {
                        BirthDate = this.random.RandomDate(minDate, maxDate),
                        Color = colors[random.RandomInt(0, colors.Count - 1)],
                        Breed = "breed " + random.RandomString(random.RandomInt(1, 23)),
                        Species = species[i],
                        Price = random.RandomInt(5, 2500)
                    };

                    context.Pets.Add(pet);
                }

                if (i % 10 == 0)
                {
                    Console.WriteLine("Pet filled: " + i * 50);
                }
            }
            context.SaveChanges();
            Console.WriteLine("Seed pets finished");
        }

        private void Products()
        {
            Console.WriteLine("Seed products begin");
            var species = this.context.Species.ToList();
            var categories = this.context.Categories.ToList();
            for (int cat = 0; cat < categories.Count; cat++)
            {
                for (int i = 0; i < 400; i++)
                {
                    var product = new Product()
                    {
                        Category = categories[cat],
                        Name = "Product " + random.RandomString(random.RandomInt(0, 11)),
                        Price = random.RandomInt(10, 1000)
                    };

                    var speciesForProduct = random.RandomInt(2, 10);
                    HashSet<Species> speciesUnique = new HashSet<Species>();
                    while (speciesUnique.Count < speciesForProduct)
                    {
                        var specie = species[random.RandomInt(0, species.Count - 1)];
                        if (!speciesUnique.Contains(specie))
                        {
                            speciesUnique.Add(specie);
                            product.Species.Add(specie);
                        }
                    }

                    context.Products.Add(product);
                }

                Console.WriteLine("Products created " + cat * 400);
            }

            context.SaveChanges();
            Console.WriteLine("Seed products finished");
        }

    }
}
