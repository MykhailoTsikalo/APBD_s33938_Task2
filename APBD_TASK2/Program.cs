using APBD_TASK2.Models;
using APBD_TASK2.Service;
using APBD_TASK2.Database;

var db = Singleton.Instance;
var service = new RentalService();

var l1 = new Laptop("Dell XPS", "High end", 16, 13);
var p1 = new Projector("Epson EB", "4K Projector", "3840x2160");
var c1 = new Camera("Canon EOS", "DSLR Camera", 24, true);
service.AddEquipment(l1);
service.AddEquipment(p1);
service.AddEquipment(c1);

var student = new Student("John", "Doe");
var employee = new Employee("Jane", "Smith");
service.AddUser(student);
service.AddUser(employee);

Console.WriteLine("\n////Scenario: VALID RENTAL");
service.RentEquipment(student.ID, l1.ID, 7);
Console.WriteLine($"{l1.Name} rented to {student.Name}");

//UNAVAILABLE EQUIPMENT
Console.WriteLine("\n////Scenario: UNAVAILABLE EQUIPMENT");
try{
    service.MarkAsUnavailable(p1.ID);
    service.RentEquipment(employee.ID, p1.ID, 5);
}
catch (Exception ex)
{
    Console.WriteLine("Expected Error: " + ex.Message);
}

//Invalid operation (exceeding student limit(2))
Console.WriteLine("\n////Scenario: EXCEEDING LIMIT");
try
{
    var l2 = new Laptop("MacBook", "Pro", 16, 14);
    var c2 = new Camera("Nikon D3500", "Entry DSLR", 20, true);
    service.AddEquipment(l2);
    service.AddEquipment(c2);

    service.RentEquipment(student.ID, l2.ID, 7);
    service.RentEquipment(student.ID, c2.ID, 7);
}
catch (Exception ex)
{
    Console.WriteLine($"Expected Error: {ex.Message}");
}

//Late return demonstration
Console.WriteLine("\n////Scenario: LATE RETURN");

foreach (var r in db.Rentals)
{
    if (r.Renter.ID == student.ID && r.ReturnDate == null)
    {
        r.DateDue = DateTime.Now.AddDays(-8);
        break;
    }
}
double penalty = service.ReturnEquipment(l1.ID);
Console.WriteLine("Returned Dell XPS. Penalty calculated: " + penalty.ToString("C"));


Console.WriteLine("\n/////Final report");
service.DisplayOverdueRentals();
// Custom Summary
Console.WriteLine("\n///System summary");
Console.WriteLine("Total Items: " + db.Equipment.Count);
Console.WriteLine("Active Rentals: " + db.Rentals.Count);