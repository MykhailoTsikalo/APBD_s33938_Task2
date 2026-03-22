using APBD_TASK2.Database;
using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Service
{
    public class RentalService : IRentalService
    {
        private Singleton _db = Singleton.Instance;
        private double DailyPenaltyRate = 10.0;

        public void AddUser(User user) { _db.Users.Add(user); }
        public void AddEquipment(Equipment equipment) { _db.Equipment.Add(equipment); }
        public List<Equipment> GetAllEquipment() { return _db.Equipment; }
        public List<Equipment> GetAvailableEquipment()
        {
            List<Equipment> available = new List<Equipment>();
            foreach (Equipment item in _db.Equipment)
            {
                if (item.IsAvailable) { available.Add(item); }
            }
            return available;
        }

        public void RentEquipment(int userId, int equipmentId, int days)
        {
            User user = null;
            foreach (User u in _db.Users)
            {
                if (u.ID == userId) { user = u; break; }
            }

            Equipment item = null;
            foreach (Equipment e in _db.Equipment)
            {
                if (e.ID == equipmentId) { item = e; break; }
            }

            if (user == null) { throw new Exception("User not found."); }
            if (item == null) { throw new Exception("Equipment not found."); }

            if (item.IsAvailable == false) {throw new Exception("Equipment is currently unavailable.");}

            int activeCount = 0;
            foreach (Rental r in _db.Rentals)
            {
                if (r.Renter.ID == userId && r.ReturnDate == null) {activeCount++;}
            }

            if (activeCount >= user.MaxRentals)
            {
                throw new Exception("User limit reached.");
            }

            item.IsAvailable = false;
            Rental newRental = new Rental(item, user, days);
            _db.Rentals.Add(newRental);
        }

        public double ReturnEquipment(int equipmentId)
        {
            Rental activeRental = null;
            foreach (Rental r in _db.Rentals)
            {
                if (r.Equipment.ID == equipmentId && r.ReturnDate == null){
                    activeRental = r;
                    break;
                }
            }

            if (activeRental == null){
                throw new Exception("Active rental not found.");
            }

            double penalty = 0;
            if (DateTime.Now > activeRental.DateDue){
                TimeSpan span = DateTime.Now - activeRental.DateDue;
                int delayDays = (int)Math.Ceiling(span.TotalDays);
                if (delayDays > 0)
                {
                    penalty = delayDays * DailyPenaltyRate;
                }
            }

            activeRental.MarkReturned(penalty);
            activeRental.Equipment.IsAvailable = true;
            return penalty;
        }

        public void DisplayReport() {
            Console.WriteLine("////System Report");
            Console.WriteLine($"Total Equipment: {_db.Equipment.Count}");
            Console.WriteLine($"Total Users: {_db.Users.Count}");
            Console.WriteLine($"Active Rentals: {_db.Rentals.Count(r => r.ReturnDate == null)}");
        }

        public void DisplayOverdueRentals() {
            Console.WriteLine("/////Overdue Rentals");
            bool fount = false;
            foreach (var r in _db.Rentals) 
            {
                if (r.ReturnDate == null && DateTime.Now > r.DateDue){
                    Console.WriteLine($"{r.Equipment.Name} rented by {r.Renter.Name} {r.Renter.Surname} is OVERDUE!");
                    fount = true;
                }
            }
            if (fount == false) { Console.WriteLine("No overdue rentals"); }
        }

        public void MarkAsUnavailable(int equipmentId)
        {
            foreach (Equipment e in _db.Equipment)
            {
                if (e.ID == equipmentId){
                    e.IsAvailable = false;
                    break;
                }
            }
        }
    }
}
