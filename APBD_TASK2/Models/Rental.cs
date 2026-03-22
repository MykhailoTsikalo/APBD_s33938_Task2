using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Models
{
    public class Rental
    {
        public Equipment Equipment { get; set; }
        public User Renter { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime? ReturnDate { get; set; }
        public double PenaltyPaid { get; set; }

        public Rental(Equipment equipment, User user, int days)
        {
            Equipment = equipment;
            Renter = user;
            RentalDate = DateTime.Now;
            DateDue = DateTime.Now.AddDays(days);
            ReturnDate = null;
            PenaltyPaid = 0;
        }

        public void MarkReturned(double penalty) {
            ReturnDate = DateTime.Now;
            PenaltyPaid = penalty;
        }

        public bool IsOverdue { get{return !ReturnDate.HasValue && DateTime.Now > DateDue;} }
    }
}
