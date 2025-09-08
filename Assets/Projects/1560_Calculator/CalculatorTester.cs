using CodeMonkey.CSharpCourse.L1500_Projects;
using CodeMonkey.Utils;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace CodeMonkey.CSharpCourse.L1560_Calculator {

    public class CalculatorTester : MonoBehaviour {



        private void Start() {
            PrintMenu();

            ProjectsConsole.Instance.RegisterCommand(new string[] { "1", "calculator" }, () => {
                Console.WriteLine("Starting Calculator...");
                ConsoleUtils.StartThread(StartCalculator, PrintMenu);
            });

            ProjectsConsole.Instance.RegisterCommand(new string[] { "2", "calculatorDone" }, () => {
                Console.WriteLine("Starting Calculator Done...");
                ConsoleUtils.StartThread(StartCalculatorDone, PrintMenu);
            });
        }

        private void PrintMenu() {
            Console.WriteLine("Valid Commands:");
            Console.WriteLine("- 1, calculator");
            Console.WriteLine("- 2, calculatorDone");
        }

        private void StartCalculator() {
            new Calculator();
        }

        private void StartCalculatorDone() {
            new Calculator_Done();
        }

    }

}