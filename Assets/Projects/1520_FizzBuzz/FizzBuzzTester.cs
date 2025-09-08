using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.CSharpCourse.L1500_Projects;
using CodeMonkey.Utils;


namespace CodeMonkey.CSharpCourse.L1520_FizzBuzz {

    public class FizzBuzzTester : MonoBehaviour {


        private List<string> outputList;


        private void Awake() {
            outputList = new List<string>();
        }

        private void Start() {
            PrintMenu();

            ProjectsConsole.Instance.RegisterCommand(new string[] { "1", "fizzBuzz" }, () => {
                Console.WriteLine("Starting FizzBuzz...");
                FunctionTimer.Create(() => {
                    ProjectsConsole.Instance.OnWriteLine += Console_OnWriteLine;
                    ProjectsConsole.Instance.OnWriteLineQueueEmptied += Console_OnWriteLineQueueEmptied;
                    ProjectsConsole.Instance.SetWriteLineQueueTimerMax(0.1f);
                    new FizzBuzz();
                }, 1f);
            });

            ProjectsConsole.Instance.RegisterCommand(new string[] { "2", "fizzBuzzDone" }, () => {
                Console.WriteLine("Starting FizzBuzz Done...");
                FunctionTimer.Create(() => {
                    ProjectsConsole.Instance.OnWriteLine += Console_OnWriteLine;
                    ProjectsConsole.Instance.OnWriteLineQueueEmptied += Console_OnWriteLineQueueEmptied;
                    ProjectsConsole.Instance.SetWriteLineQueueTimerMax(0.1f);
                    new FizzBuzz_Done();
                }, 1f);
            });
        }

        private void PrintMenu() {
            Console.WriteLine("Valid Commands:");
            Console.WriteLine("- 1, fizzBuzz");
            Console.WriteLine("- 2, fizzBuzzDone");
        }

        private void Console_OnWriteLineQueueEmptied(object sender, System.EventArgs e) {
            ProjectsConsole.Instance.OnWriteLine -= Console_OnWriteLine;
            ProjectsConsole.Instance.OnWriteLineQueueEmptied -= Console_OnWriteLineQueueEmptied;

            ProjectsConsole.Instance.OnWriteLineQueueEmptied += Console_OnWriteLineQueueEmptied_PrintMenu;

            ProjectsConsole.Instance.SetWriteLineQueueTimerMax(1f);

            bool correct100Prints = false;
            bool correctNumber1 = false;
            bool correctNumber3 = false;
            bool correctNumber5 = false;
            bool correctNumber15 = false;
            bool correctNumber100 = false;

            Console.WriteLine("Checking if got 100 prints...");
            Console.WriteLineExpected("100", outputList.Count);

            if (outputList.Count == 100) {
                correct100Prints = true;
                Console.WriteLineCorrect();
            } else {
                Console.WriteLineIncorrect();
                return;
            }

            Console.WriteLine("-");

            Console.WriteLine("Checking Value number 1...");
            string output = outputList[0];
            Console.WriteLineExpected("1", output);

            if (output == "1") {
                correctNumber1 = true;
                Console.WriteLineCorrect();
            } else {
                Console.WriteLineIncorrect();
            }

            Console.WriteLine("-");

            Console.WriteLine("Checking Value number 3...");
            output = outputList[2];
            Console.WriteLineExpected("Fizz", output);

            if (output == "Fizz") {
                correctNumber3 = true;
                Console.WriteLineCorrect();
            } else {
                Console.WriteLineIncorrect();
            }

            Console.WriteLine("-");

            Console.WriteLine("Checking Value number 5...");
            output = outputList[4];
            Console.WriteLineExpected("Buzz", output);

            if (output == "Buzz") {
                correctNumber5 = true;
                Console.WriteLineCorrect();
            } else {
                Console.WriteLineIncorrect();
            }

            Console.WriteLine("-");

            Console.WriteLine("Checking Value number 15...");
            output = outputList[14];
            Console.WriteLineExpected("FizzBuzz", output);

            if (output == "FizzBuzz") {
                correctNumber15 = true;
                Console.WriteLineCorrect();
            } else {
                Console.WriteLineIncorrect();
            }

            Console.WriteLine("-");

            Console.WriteLine("Checking Value number 100...");
            output = outputList[99];
            Console.WriteLineExpected("Buzz", output);

            if (output == "Buzz") {
                correctNumber100 = true;
                Console.WriteLineCorrect();
            } else {
                Console.WriteLineIncorrect();
            }

            Console.WriteLine("-");

            if (correct100Prints && correctNumber1 && correctNumber3 && correctNumber5 && correctNumber15 && correctNumber100) {
                Console.WriteLine($"<color=#00ff00>ALL CORRECT! GREAT JOB!</color>");
            } else {
                Console.WriteLine($"<color=#aa1111>SOMETHING INCORRECT!</color>");
            }

            ProjectsConsole.Instance.SetWriteLineQueueTimerMax(0.1f);
        }

        private void Console_OnWriteLineQueueEmptied_PrintMenu(object sender, System.EventArgs e) {
            ProjectsConsole.Instance.OnWriteLineQueueEmptied -= Console_OnWriteLineQueueEmptied_PrintMenu;

            PrintMenu();
        }

        private void Console_OnWriteLine(object sender, ProjectsConsole.OnWriteLineEventArgs e) {
            outputList.Add(e.line);
        }

    }

}