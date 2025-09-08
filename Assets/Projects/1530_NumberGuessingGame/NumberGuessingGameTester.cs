using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.CSharpCourse.L1500_Projects;
using CodeMonkey.Utils;
using System.Threading;


namespace CodeMonkey.CSharpCourse.L1530_NumberGuessingGame {

    public class NumberGuessingGameTester : MonoBehaviour {


        private void Start() {
            PrintMenu();

            ProjectsConsole.Instance.RegisterCommand(new string[] { "1", "numberGuessingGame" }, () => {
                Console.WriteLine("Starting Number Guessing Game...");
                ConsoleUtils.StartThread(StartNumberGuessingGame, PrintMenu);
            });

            ProjectsConsole.Instance.RegisterCommand(new string[] { "2", "numberGuessingGameDone" }, () => {
                Console.WriteLine("Starting Number Guessing Game Done...");
                ConsoleUtils.StartThread(StartNumberGuessingGameDone, PrintMenu);
            });
        }

        private void PrintMenu() {
            Console.WriteLine("Valid Commands:");
            Console.WriteLine("- 1, numberGuessingGame");
            Console.WriteLine("- 2, numberGuessingGameDone");
        }

        private void StartNumberGuessingGame() {
            new NumberGuessingGame();
        }

        private void StartNumberGuessingGameDone() {
            new NumberGuessingGame_Done();
        }

    }

}