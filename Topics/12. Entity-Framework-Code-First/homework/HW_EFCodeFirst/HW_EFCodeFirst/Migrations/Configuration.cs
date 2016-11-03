namespace HW_EFCodeFirst.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HW_EFCodeFirst.AcademyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HW_EFCodeFirst.AcademyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var students = new Student[]
                {
                new Student { Name = "Angel Ivanov", Number="22" },
                new Student { Name = "Pavel Pavlov" , Number="33"},
                new Student { Name = "Andrew Peters" , Number="44"}
                };
            var courses = new Course[]
            {
                new Course {Name="JS Applications" , Description="JS Applications at Telerik Academy"},
                new Course { Name="Design Patterns", Description="Design Patterns at  Telerik Academy" }
            };

            students[0].Courses.Add(courses[0]);
            students[0].Courses.Add(courses[1]);
            courses[0].Students.Add(students[1]);
            courses[0].Students.Add(students[2]);
            courses[1].Students.Add(students[1]);

            context.Students.AddOrUpdate(s => s.Name, students);
            context.Courses.AddOrUpdate(c => c.Name, courses);

            var homemork = new Homework
            {
                Content = "...files..",
                TimeSent = new DateTime(2016, 11, 02),
                Course = courses[0],
                Student = students[0]
            };
            context.Homeworks.AddOrUpdate(h => h.Content, homemork);
        }
    }
}
