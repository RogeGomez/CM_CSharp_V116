using CodeMonkey.CSharpCourse.L1500_Projects;
using CodeMonkey.Utils;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace CodeMonkey.CSharpCourse.L1600_PasswordGenerator {

    public class PasswordGeneratorTester : MonoBehaviour {



        private void Start() {
            PrintMenu();

            ProjectsConsole.Instance.RegisterCommand(new string[] { "1", "passwordGenerator" }, () => {
                Console.WriteLine("Starting Password Generator...");
                ConsoleUtils.StartThread(StartPasswordGenerator, PrintMenu);
            });

            ProjectsConsole.Instance.RegisterCommand(new string[] { "2", "passwordGeneratorDone" }, () => {
                Console.WriteLine("Starting Password Generator Done...");
                ConsoleUtils.StartThread(StartPasswordGeneratorDone, PrintMenu);
            });
        }

        private void PrintMenu() {
            Console.WriteLine("Valid Commands:");
            Console.WriteLine("- 1, passwordGenerator");
            Console.WriteLine("- 2, passwordGeneratorDone");
        }

        private void StartPasswordGenerator() {
            new PasswordGenerator();
        }

        private void StartPasswordGeneratorDone() {
            new PasswordGenerator_Done();
        }

    }

}