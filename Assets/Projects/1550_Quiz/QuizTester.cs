using CodeMonkey.CSharpCourse.L1500_Projects;
using CodeMonkey.Utils;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace CodeMonkey.CSharpCourse.L1550_Quiz {

    public class QuizTester : MonoBehaviour {



        private void Start() {
            PrintMenu();

            ProjectsConsole.Instance.RegisterCommand(new string[] { "1", "quiz" }, () => {
                Console.WriteLine("Starting Quiz...");
                ConsoleUtils.StartThread(StartQuiz, PrintMenu);
            });

            ProjectsConsole.Instance.RegisterCommand(new string[] { "2", "quizDone" }, () => {
                Console.WriteLine("Starting Quiz Done...");
                ConsoleUtils.StartThread(StartQuizDone, PrintMenu);
            });
        }

        private void PrintMenu() {
            Console.WriteLine("Valid Commands:");
            Console.WriteLine("- 1, quiz");
            Console.WriteLine("- 2, quizDone");
        }

        private void StartQuiz() {
            new Quiz();
        }

        private void StartQuizDone() {
            new Quiz_Done();
        }

    }

}