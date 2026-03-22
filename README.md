Design Decisions and SOLID Principles
1) Cohesion
I have separated the logic into distinct layers to ensure each class has one responsibility:
 * Models (Equipment, User, Rental): They store data and represent the domain.
 * Service (RentalService): This class contains the business logic. It doesn't know about the console, it only knows how to process rentals, check limits, 
	and calculate penalties.
 * Database (Singleton): Acts as a simple in-memory data store, separating data persistence from business logic.
 
2) Coupling and Abstraction
Interfaces: I used the IRentalService interface. This decouples the Program.cs from the specific implementation of the rental logic. If we wanted to change 
how rentals work, we could create a new service without changing the main program.
Dependency: The Program.cs interacts with the service layer rather than manipulating the "database" directly

3) Inheritance vs. Composition
I used an abstract base class for Equipment and User. This is a "sensible" use of inheritance because a Laptop is a type of Equipment. This allowed me to share 
common fields (ID, Name) while forcing specific types to implement their own GetDetails() methods.

4) Business Rules
User Limits: Handled inside the RentalService by checking the MaxRentals property of the User subclasses.
Penalty Logic: Implemented using a DailyPenaltyRate constant. I used Math.Ceiling on the TotalDays late to ensure even partial days result in a full day's 
penalty, making the rule clear and easy to modify in one place.

--------

The Program.cs file demonstrates:
* Successful registration of 3 types of equipment.
* Successful rental for a student.
* Blocked rental when equipment is marked as "Unavailable."
* Blocked rental when a student exceeds their limit of 2 items.
* A late return calculation showing a calculated penalty.