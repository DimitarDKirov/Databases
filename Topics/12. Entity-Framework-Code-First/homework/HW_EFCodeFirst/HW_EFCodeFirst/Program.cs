using HW_EFCodeFirst.Migrations;
using HW_EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_EFCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AcademyContext, Configuration>());

            var db = new AcademyContext();
            //var student = new Student
            //{
            //    Name = "Petko Todorov",
            //    Number = "111111"
            //};

            //var course = new Course
            //{
            //    Name = "Databases",
            //    Description = "course Databases at Telerik Academy",
            //};

            //var homework = new Homework
            //{
            //    Content = "many files",
            //    TimeSent = DateTime.Now
            //};

            //student.Courses.Add(course);
            //student.Homeworks.Add(homework);

            //db.Students.Add(student);
            //db.SaveChanges();

            Console.WriteLine(db.Students.First().Name);
        }
    }
}
