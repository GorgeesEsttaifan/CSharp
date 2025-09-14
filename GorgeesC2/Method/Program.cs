using System;

namespace MathOperationApp
{
    // This is the class that contains the custom method
    class MathProcessor
    {
        // This void method takes two integers as parameters
        // It performs a math operation on the first integer
        // and displays the second integer
        public void ProcessNumbers(int num1, int num2)
        {
            // Perform a math operation on the first number (e.g., multiply by 2)
            int result = num1 * 2;

            // Display the result of the operation on the first number
            Console.WriteLine("Result of math operation on the first number (num1 * 2): " + result);

            // Display the second number
            Console.WriteLine("Second number (num2): " + num2);
        }
    }

    // The Program class contains the Main() method which is the entry point of the application
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the MathProcessor class so we can use its method
            MathProcessor processor = new MathProcessor();

            // Call the method by passing two integers directly
            processor.ProcessNumbers(10, 20);

            // Call the method again using named parameters
            processor.ProcessNumbers(num1: 5, num2: 10);

            // Wait for user input so the console doesn't close instantly
            Console.WriteLine("Press any key to exit....");
            Console.ReadKey();
        }
    }
}
