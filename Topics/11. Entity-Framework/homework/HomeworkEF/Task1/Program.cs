using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {
                Customer newCustomer = new Customer()
                {
                    CustomerID = "TELEK",
                    CompanyName = "Telerik",
                    ContactName = "Peter Petrov",
                    ContactTitle = "Dr."
                };

                string newCustomerId = dbDaoTask2.InsertCustomer(newCustomer);
                Console.WriteLine("New customer inserted");
                var lastCustomer = db.Customers
                    .Where(cust => cust.CustomerID == newCustomerId)
                    .Select(c => new
                    {
                        ContactName = c.ContactName,
                        CompanyName = c.CompanyName
                    })
                    .FirstOrDefault();
                Console.WriteLine("Name {0}, Company {1}", lastCustomer.ContactName, lastCustomer.CompanyName);

                dbDaoTask2.RemoveCustomer(newCustomerId);
                Console.WriteLine("Customer removed");
            }
        }
    }
}
