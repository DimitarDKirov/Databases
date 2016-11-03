using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//2. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers.
    //Write a testing class.

namespace Task1
{
    static class dbDaoTask2
    {
        public static string InsertCustomer(Customer customer)
        {
            using(var db=new NorthwindEntities())
            {
                try
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                }
                catch (Exception e) { };
                return customer.CustomerID;
            }
        }

        public static void UpdateCustomer(Customer updatedCustomer)
        {
            using(var db=new NorthwindEntities())
            {
                db.Customers.Attach(updatedCustomer);
                db.SaveChanges();
            }
        }

        public static void RemoveCustomer(string removeCustomerId)
        {
            using(var db=new NorthwindEntities())
            {
                Customer customer = db.Customers.FirstOrDefault(cust => cust.CustomerID == removeCustomerId);
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }
    }
}
