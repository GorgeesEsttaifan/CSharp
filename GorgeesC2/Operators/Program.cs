using System;

// Define the namespace for our console application
namespace EmployeeComparisonApp
{
    // Define the Employee class
    class Employee
    {
        // Property to store the employee's ID
        public int Id { get; set; }

        // Property to store the employee's first name
        public string FirstName { get; set; }

        // Property to store the employee's last name
        public string LastName { get; set; }

        // Override the == operator to compare two Employee objects by their Id
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // If both are null, or both are same instance, return true
            if (ReferenceEquals(emp1, emp2))
                return true;

            // If one is null, but not both, return false
            if (((object)emp1 == null) || ((object)emp2 == null))
                return false;

            // Compare their Ids for equality
            return emp1.Id == emp2.Id;
        }

        // Override the != operator to complement the == operator
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }

        // Override Equals to match the behavior of the == operator
        public override bool Equals(object obj)
        {
            // Check if the object is an Employee
            var other = obj as Employee;
            if (other == null)
                return false;

            return this.Id == other.Id;
        }

        // Override GetHashCode whenever Equals is overridden
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }

    // Main class containing the application entry point
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the first Employee object
            Employee emp1 = new Employee
            {
                Id = 111,
                FirstName = "Gorgees",
                LastName = "Esttaifan"
            };

            // Instantiate the second Employee object
            Employee emp2 = new Employee
            {
                Id = 111,
                FirstName = "Some",
                LastName = "Name"
            };

            // Compare the two Employee objects using the overloaded == operator
            bool areEqual = emp1 == emp2;

            // Display the result of the comparison
            Console.WriteLine("Are emp1 and emp2 equal (==)? " + areEqual);

            // Use the overloaded != operator to compare again
            bool areNotEqual = emp1 != emp2;

            // Display the result of the inequality comparison
            Console.WriteLine("Are emp1 and emp2 not equal (!=)? " + areNotEqual);

            // Wait for the user to press a key before exiting
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
