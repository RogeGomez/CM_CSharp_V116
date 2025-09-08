using CodeMonkey.CSharpCourse.L1500_Projects;
using System.Collections.Generic;
using static Cinemachine.DocumentationSortingAttribute;

namespace CodeMonkey.CSharpCourse.L1570_Hangman {

    public class Hangman {


        /* ** Hangman **
         * 
         * Computer generates hidden word
         * Player tries to guess letter by letter
         * 
         * If they get it right, 
         * all instances of the letter show up
         * If they get it wrong,
         * a part of the body is added to the gallows
         * If 6 wrong, lose
         * If got all letters right, win
         * 
         * Hint: You can do a foreach on a string to cycle through each char (letter) on the string
         *       foreach (char c in string)  {  }
         * */
        public Hangman() {

        }

        private int GenerateRandomNumber(int maxExclusive) {
            // Generates a random number between 0 (inclusive) and maxExclusive (exclusive)
            return new System.Random().Next(maxExclusive);
        }

        private void PrintGallows0() {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }

        private void PrintGallows1() {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }

        private void PrintGallows2() {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine("  |   |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }

        private void PrintGallows3() {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine(" /|   |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }

        private void PrintGallows4() {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine(" /|\\  |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }

        private void PrintGallows5() {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine(" /|\\  |");
            Console.WriteLine(" /    |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }

        private void PrintGallows6() {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine(" /|\\  |");
            Console.WriteLine(" / \\  |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }

    }

}