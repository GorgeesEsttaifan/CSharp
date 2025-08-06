using System;

namespace PackageExpressQuote
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display welcome message
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

            // Prompt user to enter package weight
            Console.WriteLine("Please enter the package weight:");
            double weight = Convert.ToDouble(Console.ReadLine()); // Read and convert user input to double

            // Check if weight is over the limit
            if (weight > 50)
            {
                // Display message and end program if too heavy
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                return; // Exit the program
            }

            // Prompt user to enter package width
            Console.WriteLine("Please enter the package width:");
            double width = Convert.ToDouble(Console.ReadLine()); // Read and convert width

            // Prompt user to enter package height
            Console.WriteLine("Please enter the package height:");
            double height = Convert.ToDouble(Console.ReadLine()); // Read and convert height

            // Prompt user to enter package length
            Console.WriteLine("Please enter the package length:");
            double length = Convert.ToDouble(Console.ReadLine()); // Read and convert length

            // Check if the total dimensions exceed the limit
            double dimensionTotal = width + height + length; // Calculate total size
            if (dimensionTotal > 50)
            {
                // Display message and end program if package is too large
                Console.WriteLine("Package too big to be shipped via Package Express.");
                return; // Exit the program
            }

            // Calculate quote using the formula: (height * width * length * weight) / 100
            double quote = (width * height * length * weight) / 100;

            // Display the shipping quote formatted as currency
            Console.WriteLine("Your estimated total for shipping this package is: $" + quote.ToString("F2"));
            Console.WriteLine("Thank you!"); // Thank the user
        }
    }
}
