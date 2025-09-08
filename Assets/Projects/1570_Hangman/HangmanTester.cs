using CodeMonkey.CSharpCourse.L1500_Projects;
using CodeMonkey.Utils;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace CodeMonkey.CSharpCourse.L1570_Hangman {

    public class HangmanTester : MonoBehaviour {



        private void Start() {
            PrintMenu();

            ProjectsConsole.Instance.RegisterCommand(new string[] { "1", "hangman" }, () => {
                Console.WriteLine("Starting Hangman...");
                ConsoleUtils.StartThread(StartHangman, PrintMenu);
            });

            ProjectsConsole.Instance.RegisterCommand(new string[] { "2", "hangmanDone" }, () => {
                Console.WriteLine("Starting Hangman Done...");
                ConsoleUtils.StartThread(StartHangmanDone, PrintMenu);
            });
        }

        private void PrintMenu() {
            Console.WriteLine("Valid Commands:");
            Console.WriteLine("- 1, hangman");
            Console.WriteLine("- 2, hangmanDone");
        }

        private void StartHangman() {
            new Hangman();
        }

        private void StartHangmanDone() {
            new Hangman_Done();
        }

    }

}