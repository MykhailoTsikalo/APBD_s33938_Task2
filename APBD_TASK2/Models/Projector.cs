using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Models
{
    internal class Projector : Equipment
    {
        public string Resolution { get; set; }
        public Projector(string name, string desc, string res) : base(name, desc) {
            Resolution = res;
        }

        public override string GetDetails()
        {
            return $"Projector: {Name} ({Resolution})";
        }
    }
}
