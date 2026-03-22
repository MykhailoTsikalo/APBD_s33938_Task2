using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Models
{
    internal class Laptop : Equipment
    {
        public int RAM { get; set; }

        public int ScreenSize { get; set; }

        public Laptop(string name, string description, int ramGb, int screenSize) 
            : base(name, description) 
        {
            RAM = ramGb;
            ScreenSize = screenSize;    
        }

        public override string GetDetails() {
            return $"Laptop {Name} - {RAM}GB RAM";
        }
    }
}
