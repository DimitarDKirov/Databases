using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_EFCodeFirst.Models
{
    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Homework> homeworks;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
        }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
