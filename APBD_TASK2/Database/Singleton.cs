using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APBD_TASK2.Models;

namespace APBD_TASK2.Database
{
    public class Singleton
    {
        private static Singleton? _instance;
        public static Singleton Instance
        {
            get
            {
                _instance ??= new Singleton();
                return _instance;
            }
        }

        public List<Equipment> Equipment { get; } = new();
        public List<User> Users { get; } = new();
        public List<Rental> Rentals { get; } = new();

        private Singleton() { }
    }
}
