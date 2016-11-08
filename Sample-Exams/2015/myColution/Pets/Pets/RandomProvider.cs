using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets
{
    public class RandomProvider
    {
        private Random random;

        public RandomProvider()
        {
            this.random = new Random();
        }

        public int RandomInt(int min = 0, int max = int.MaxValue / 2)
        {
            return this.random.Next(min, max + 1);
        }

        public string RandomString(int length=50)
        {
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = (char)('a' + this.RandomInt(0, 26));
            }

            return new string(result);
        }

        public DateTime RandomDate(DateTime min, DateTime max)
        {
            var date = min.AddDays(this.RandomInt(1, (max.Year - min.Year) * 365));
            return date;
        }
    }
}
