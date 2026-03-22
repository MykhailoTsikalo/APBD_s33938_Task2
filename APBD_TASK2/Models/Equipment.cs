using APBD_TASK2.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Models
{
    public abstract class Equipment
    {
        private static int _nextId = 1;

        public int ID { get;  }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsAvailable { get; set; } = true;
        public EquipmentStatus Status { get; set; }

        public DateTime AddedDate { get; set; }

        public Equipment(string name, string description) {
            ID = _nextId++;
            Name = name;
            Description = description;
        }

        public abstract string GetDetails();

    }
}
