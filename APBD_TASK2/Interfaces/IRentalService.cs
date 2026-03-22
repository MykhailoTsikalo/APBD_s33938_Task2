using APBD_TASK2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Interfaces
{
    public interface IRentalService
    {
        void AddUser(User user);
        void AddEquipment(Equipment equipment);
        List<Equipment> GetAllEquipment();
        List<Equipment> GetAvailableEquipment();

        void RentEquipment(int userId, int equipmentId, int days);
        double ReturnEquipment(int equipmentId);
    }
}
