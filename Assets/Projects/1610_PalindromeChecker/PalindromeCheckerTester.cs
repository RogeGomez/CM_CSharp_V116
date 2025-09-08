using CodeMonkey.CSharpCourse.L1500_Projects;
using CodeMonkey.Utils;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace CodeMonkey.CSharpCourse.L1610_PalindromeChecker {

    public class PalindromeCheckerTester : MonoBehaviour {



        private void Start() {
            PrintMenu();

            ProjectsConsole.Instance.RegisterCommand(new string[] { "1", "palindromeChecker" }, () => {
                Console.WriteLine("Starting Palindrome Checker...");
                ConsoleUtils.StartThread(StartPalindromeChecker, PrintMenu);
            });

            ProjectsConsole.Instance.RegisterCommand(new string[] { "2", "palindromeCheckerDone" }, () => {
                Console.WriteLine("Starting Palindrome Checker...");
                ConsoleUtils.StartThread(StartPalindromeCheckerDone, PrintMenu);
            });
        }

        private void PrintMenu() {
            Console.WriteLine("Valid Commands:");
            Console.WriteLine("- 1, palindromeChecker");
            Console.WriteLine("- 2, palindromeCheckerDone");
        }

        private void StartPalindromeChecker() {
            new PalindromeChecker();
        }

        private void StartPalindromeCheckerDone() {
            new PalindromeChecker_Done();
        }

    }

}