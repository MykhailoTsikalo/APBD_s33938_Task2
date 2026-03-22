using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Models
{
    public abstract class User
    {
        private static int nextID = 1;

        public int ID { get; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public abstract int MaxRentals { get; }

        public User(string name, string surname)
        {
            ID = nextID++;
            Name = name;
            Surname = surname;
        }
    }


    public class Student : User { 
        public Student(string fn, string ln) : base (fn, ln) { }
        public override int MaxRentals { get { return 2; } }
    }


    public class Employee : User {
        public Employee(string fn, string ln) : base(fn, ln) { }
        public override int MaxRentals { get { return 5; } }
    }
}
