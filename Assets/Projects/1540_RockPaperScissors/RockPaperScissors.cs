using CodeMonkey.CSharpCourse.L1500_Projects;

namespace CodeMonkey.CSharpCourse.L1540_RockPaperScissors {

    public class RockPaperScissors {


        /* ** Rock Paper Scissors **
         * 
         * There are 3 Actions
         * Rock, Paper, Scissors
         * 
         * Rock beats Scissors
         * Scissors beats Paper
         * Paper beats Rock
         * 
         * Computer generates Action
         * Asks player for input
         * Prints result
         * 
         * Hint: You can generate random numbers with new System.Random().Next(3);
         *       Generates between 0 (inclusive) and 3 (exclusive)
         * */
        public RockPaperScissors() {

        }

        private int GenerateRandomNumber() {
            // Generates a random number between 0 (include) and 3 (exclusive)
            return new System.Random().Next(3);
        }

    }

}