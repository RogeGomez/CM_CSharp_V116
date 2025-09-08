using CodeMonkey.CSharpCourse.L1500_Projects;

namespace CodeMonkey.CSharpCourse.L1530_NumberGuessingGame {

    public class NumberGuessingGame_Done {


        /* ** Number Guessing Game **
         * 
         * Generate Random Number
         * Ask player to guess a number
         * If they get it right they win
         * If not, print Higher or Lower
         * Keep going until player guesses correct
         * 
         * Hint: Use Console.ReadLine();  to get input, but it returns a string, you must convert into int
         * In the Companion Project I added Console.ReadLineInt(); which already returns an int
         * Use while (true) to keep trying over and over again, and use break; to exit the infinite loop
         * */
        public NumberGuessingGame_Done() {
            Console.WriteLine("Number Guessing Game!");
            Console.WriteLine("-");

            int randomNumber = GenerateRandomNumber();

            Console.WriteLine("Generated Random Number...");
            Console.WriteLine("-");

            while (true) {
                Console.WriteLine("Guess the Number:");
                int number = Console.ReadLineInt();
                if (number == randomNumber) {
                    Console.WriteLine("<color=#00ff00>You Win!</color>");
                    break;
                } else {
                    if (number < randomNumber) {
                        Console.WriteLine("Higher");
                    } else {
                        Console.WriteLine("Lower");
                    }
                }
            }
        }

        private int GenerateRandomNumber() {
            // Generates a random number between 0 (include) and 100 (exclusive)
            return new System.Random().Next(100);
        }

    }

}