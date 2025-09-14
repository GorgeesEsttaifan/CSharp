using System;

namespace EmployeeQuitApp
{
    // Define an interface called IQuittable
    interface IQuittable
    {
        // Declare a void method named Quit
        void Quit();
    }

    // Define the Employee class
    // It inherits from the IQuittable interface
    class Employee : IQuittable
    {
        // Property to hold the employee's ID
        public int Id { get; set; }

        // Property to hold the employee's first name
        public string FirstName { get; set; }

        // Property to hold the employee's last name
        public string LastName { get; set; }

        // Implement the Quit() method from the IQuittable interface
        public void Quit()
        {
            // Simple implementation that prints a message to the console
            Console.WriteLine($"{FirstName} {LastName} (ID: {Id}) has quit the job.");
        }
    }

    // Main class that starts the application
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of Employee and assign values to properties
            Employee emp = new Employee
            {
                Id = 111,
                FirstName = "Gorgees",
                LastName = "Esttaifan"
            };

            // Use polymorphism: assign the Employee object to an IQuittable interface variable
            IQuittable quittableEmployee = emp;

            // Call the Quit() method using the interface reference
            quittableEmployee.Quit();

            Console.WriteLine("Press any key to exit....");
            Console.ReadKey();
        }
    }
}
