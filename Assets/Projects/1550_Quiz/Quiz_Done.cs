using CodeMonkey.CSharpCourse.L1500_Projects;
using System.Collections.Generic;

namespace CodeMonkey.CSharpCourse.L1550_Quiz {

    public class Quiz_Done {


        /* ** Quiz **
         * 
         * Implement Questions and Answers
         * Ask player the question, player answers
         * Check if answer is correct
         * Keep asking questions until there`s no more
         * 
         * Hint: You can store multiple pieces of data in one variable using collections
         * For example a List<string> or a string[] array
         * Then you can cycle through it with: for (int i = 0; i < list.Count; i++) {   }
         * */
        public Quiz_Done() {
            List<string> questionList = new List<string>() {
                "What is the Capital of Portugal?",
                "How much is 2 + 3?",
                "Who made this course?",
            };
            List<string> answerList = new List<string>() {
                "Lisbon",
                "5",
                "Code Monkey",
            };

            Console.WriteLine("## Quiz! ##");
            for (int questionIndex = 0; questionIndex < questionList.Count; questionIndex++) {
                Console.WriteLine(questionList[questionIndex]);
                string answer = Console.ReadLine();
                if (answer == answerList[questionIndex]) {
                    Console.WriteLineCorrect();
                } else {
                    Console.WriteLineIncorrect();
                    Console.WriteLine("Correct Answer: " + answerList[questionIndex]);
                }
            }
        }

    }

}