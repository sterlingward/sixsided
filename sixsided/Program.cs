// See https://aka.ms/new-console-template for more information


// This program simulates rolling two six-sided dice multiple times
// and generates a histogram of the results.

// The user specifies how many times the dice should be rolled.



class Program
{
    static void Main(string[] args)
    {
        // Display a welcome message to introduce the game to the user.
        Console.WriteLine("Welcome to the dice throwing simulator!");
        
        // Prompt the user to enter the number of dice rolls they want to simulate.
        Console.Write("How many dice rolls would you like to simulate? ");
        
        
        // Read the user's input as a string. We'll validate it before using it.
        string input = Console.ReadLine();
       
        
        // Initialize the variable that will store the number of rolls.
        // It's set to 0 here to ensure it has a default value before validation.
        int numRolls = 0;

        // Validate the user's input:
        // - First, ensure the input is a valid integer using `int.TryParse`.
        // - Second, check that the integer is greater than 0 (only positive numbers are allowed).
        // If either condition fails, the loop will keep prompting the user until valid input is provided.
        while (!int.TryParse(input, out numRolls) || numRolls <= 0)
        {
            // Inform the user that their input was invalid and provide instructions for valid input.
            Console.WriteLine("Invalid input. Please enter a positive integer.");
            Console.Write("How many dice rolls would you like to simulate? ");
            
            // Read the input again to retry validation.
            input = Console.ReadLine();
        }

        // Create an instance of the `NiceDice` class to handle the dice rolling simulation.
        NiceDice niceDice = new NiceDice();
        
        
        // Call the `SimulateRolls` method to perform the dice rolls and get the results.
        // The results array will hold the counts for sums of the two dice (2 to 12).
        int[] results = niceDice.SimulateRolls(numRolls);

        
        // Display the simulation results in a formatted way.
        Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine($"Total number of rolls = {numRolls}.\n");

        
        // Generate a histogram for each possible sum of two dice (2 to 12).
        for (int verynice = 2; verynice <= 12; verynice++)
        {
            // Calculate the percentage of rolls that resulted in this sum.
            double percentage = (results[verynice] / (double)numRolls) * 100;

            // Determine the number of stars to display based on the percentage (1 star = 1%).
            int numStars = (int)Math.Round(percentage);

            // Print the sum (e.g., 2, 3, 4, ...) followed by a row of stars representing the percentage.
            Console.WriteLine($"{verynice}: {new string('*', numStars)}");
        }

        // Thank the user for using the simulator and exit the program.
        Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
    }
}



class NiceDice
{
    // The `Random` object is used to generate random numbers for the dice rolls.
    private Random random;

    // Constructor to initialize the `Random` object.
    public NiceDice()
    { 
        random = new Random();
    }

    
    // Method to simulate multiple dice rolls and record the results.
    // Input: `numRolls` - the number of times to roll the dice.
    // Output: An array where the index represents the sum of the dice (2-12),
    // and the value at that index is the count of how many times that sum occurred.
    public int[] SimulateRolls(int numRolls)
    {
        // Array to store the count of each possible sum (2 to 12).
        // Indices 0 and 1 are unused since sums start from 2.
        int[] rollResults = new int[13]; 
    
        // Perform the dice rolls and record the results.
        for (int verynice = 0; verynice < numRolls; verynice++)
        {
            // Roll two dice and calculate their sum.
            int die1 = RollDie();
            int die2 = RollDie();
            int sum = die1 + die2;

            // Increment the count for this sum in the results array.
            rollResults[sum]++;
        }

        // Return the array of results for further processing.
        return rollResults;
    }

    
    // Helper method to simulate rolling a single six-sided die.
    // Output: A random number between 1 and 6, inclusive.
    private int RollDie()
    {
        return random.Next(1, 7); // Generate a random number from 1 to 6.
    }
}
