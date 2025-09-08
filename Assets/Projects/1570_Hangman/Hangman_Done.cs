using CodeMonkey.CSharpCourse.L1500_Projects;
using System.Collections.Generic;

namespace CodeMonkey.CSharpCourse.L1570_Hangman {

    public class Hangman_Done {


        private string chosenWord;
        private List<char> charsGuessedList;
        private int lives;

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
        public Hangman_Done() {
            List<string> possibleWordList = new List<string>() {
                "Code Monkey",
                "Unity",
                "Galaxy",
                "Dragon Ball",
                "Naruto",
                "Mercedes",
                "Lamborghini",
                "Ferrari",
                "Programming",

            };

            charsGuessedList = new List<char>();
            lives = 6;

            Console.WriteLine("Choosing secret word...");
            Console.WriteLine("...");
            
            chosenWord = possibleWordList[GenerateRandomNumber(possibleWordList.Count)];

            Console.WriteLine("Secret word chosen!");
            Console.WriteLine("-");

            ProjectsConsole.Instance.SetWriteLineQueueTimerMax(.03f);

            PrintGallows0();
            PrintGuessState();

            while (lives > 0) {
                Console.WriteLine("Guess a Letter:");
                char guessChar = GetGuessChar().ToString().ToLower()[0];

                if (charsGuessedList.Contains(guessChar)) {
                    Console.WriteLine("Already guessed '" + guessChar + "', try another letter...");
                    continue;
                }

                charsGuessedList.Add(guessChar);

                // Is the guess right?
                if (chosenWord.ToLower().Contains(guessChar)) {
                    // Right!
                    Console.WriteLine("<color=#00ff00>There is a '" + guessChar + "' in the word!</color>");
                    if (GetMissingLetterCount() <= 0) {
                        // Win!
                        break;
                    }
                } else {
                    // Wrong!
                    Console.WriteLine("<color=#ff0000>There is no '" + guessChar + "' in the word!</color>");
                    lives--;
                }
                Console.WriteLine("Lives: " + lives);

                switch (lives) {
                    case 6:
                        PrintGallows0();
                        break;
                    case 5:
                        PrintGallows1();
                        break;
                    case 4:
                        PrintGallows2();
                        break;
                    case 3:
                        PrintGallows3();
                        break;
                    case 2:
                        PrintGallows4();
                        break;
                    case 1:
                        PrintGallows5();
                        break;
                    case 0:
                        PrintGallows6();
                        break;
                }

                PrintGuessState();
            }

            if (GetMissingLetterCount() > 0) {
                // Still missing some letters
                Console.WriteLine("<color=#ff0000>GAME OVER</color>");
                Console.WriteLine("The word was: <color=#ffff00>" + chosenWord + "</color>");
            } else {
                // Win!
                Console.WriteLine("<color=#00ff00>YOU WIN!</color>");
                Console.WriteLine("The word was: <color=#ffff00>" + chosenWord + "</color>");
            }
        }

        private char GetGuessChar() {
            while (true) {
                string guessLetter = Console.ReadLine();
                if (guessLetter.Length > 1) {
                    // More than one character, wrong guess
                    Console.WriteLine("Guess only one letter!");
                } else {
                    // Return the first character char
                    return guessLetter[0];
                }
            }
        }

        private int GenerateRandomNumber(int maxExclusive) {
            // Generates a random number between 0 (include) and maxExclusive (exclusive)
            return new System.Random().Next(maxExclusive);
        }

        private void PrintGuessState() {
            string printString = "";
            foreach (char c in chosenWord) {
                if (c == ' ') {
                    // Ignore spaces since those don't get guessed, print space and skip
                    printString += " ";
                    continue;
                }
                if (charsGuessedList.Contains(c.ToString().ToLower()[0])) {
                    // Guessed this one right
                    printString += c;
                } else {
                    printString += "_";
                }
            }
            Console.WriteLine(printString);

            string guessesString = "";
            foreach (char c in charsGuessedList) {
                guessesString += c + " ";
            }

            Console.WriteLine("Guesses: " + guessesString);
        }

        private int GetMissingLetterCount() {
            int missingLetterCount = 0;
            foreach (char c in chosenWord) {
                if (c == ' ') {
                    // Ignore spaces since those don't get guessed, print space and skip
                    continue;
                }
                if (charsGuessedList.Contains(c.ToString().ToLower()[0])) {
                    // Guessed this one right
                } else {
                    missingLetterCount++;
                }
            }
            return missingLetterCount;
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