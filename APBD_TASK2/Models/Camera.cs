using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Models
{
    internal class Camera : Equipment
    {
        public int Megapixels { get; set; }
        public bool IsDigital { get; set; }

        public Camera(string name, string desc, int mpx, bool isDig) : base(name, desc) { 
            Megapixels = mpx;
            IsDigital = isDig;
        }

        public override string GetDetails()
        {
            return $"Camera {Name} - {Megapixels}MP";
        }
    }
}
