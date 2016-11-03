using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        //3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
        private static IEnumerable<Customer> GetCustomerByOrder(int orderYear, string country)
        {
            using (var db = new NorthwindEntities())
            {
                var customers = db.Customers.
                    Join(db.Orders, c => c.CustomerID, o => o.CustomerID, (c, o) => new
                    {
                        Customer = c,
                        OrderYear = o.OrderDate.Value.Year,
                        OrderCountry = o.ShipCountry
                    })
                    .Where(r => r.OrderYear == orderYear && r.OrderCountry == country)
                    .Select(c => c.Customer)
                    .Distinct()
                    .ToList();


                //v2
                var customers2 = db.Customers
                    .Where(c => c.Orders.Any(o => o.OrderDate.Value.Year == orderYear && o.ShipCountry == country))
                    .ToList();

                return customers2;
                // return customers;
            }
        }

        //4.  Implement previous by using native SQL query and executing it through the DbContext.
        private static IEnumerable<Customer> GetCustomerBySQL(int orderYear, string country)
        {
            using (var db = new NorthwindEntities())
            {
                string queryString = "SELECT * FROM Customers c " +
                        "WHERE c.CustomerID IN " +
                        "(SELECT o.CustomerID FROM Orders o " +
                        "WHERE DATEPART(YEAR, o.OrderDate)={0} AND o.ShipCountry={1})";
                object[] parameters = { orderYear, country };
                var customers = db.Database.SqlQuery<Customer>(string.Format(queryString, parameters));

                return customers;
            }

        }

        //5. Write a method that finds all the sales by specified region and period (start / end dates).
        private static IEnumerable<Order> GetSalesByRegionAndDate(string regionName, DateTime startDate, DateTime endDate)
        {
            var db = new NorthwindEntities();
            var orders = db.Orders
                .Where(o => o.ShipRegion == regionName && o.OrderDate.Value >= startDate && o.OrderDate.Value <= endDate);

            return orders;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Customers by year and country");
            var customers = GetCustomerByOrder(1997, "Canada");
            Console.WriteLine("LINQ");
            foreach (var c in customers)
            {
                Console.WriteLine(c.CompanyName);
            }

            Console.WriteLine();
            Console.WriteLine("SQL");
            var customersFromSql = GetCustomerBySQL(1997, "Canada");
            foreach (var c in customers)
            {
                Console.WriteLine(c.CompanyName);
            }

            Console.WriteLine("Orders by region");
            var orders = GetSalesByRegionAndDate("SP", new DateTime(1990, 1, 1), DateTime.Now);
            foreach (Order order in orders)
            {
                Console.WriteLine($"Shipped to {order.ShipName} at {order.OrderDate.Value.ToShortDateString()}");
            }
        }
    }
}
