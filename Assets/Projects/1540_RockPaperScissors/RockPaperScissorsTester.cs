using CodeMonkey.CSharpCourse.L1500_Projects;
using CodeMonkey.Utils;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace CodeMonkey.CSharpCourse.L1540_RockPaperScissors {

    public class RockPaperScissorsTester : MonoBehaviour {


        private void Start() {
            PrintMenu();

            ProjectsConsole.Instance.RegisterCommand(new string[] { "1", "rockPaperScissors" }, () => {
                Console.WriteLine("Starting Rock Paper Scissors...");
                ConsoleUtils.StartThread(StartRockPaperScissors, PrintMenu);
            });

            ProjectsConsole.Instance.RegisterCommand(new string[] { "2", "rockPaperScissorsDone" }, () => {
                Console.WriteLine("Starting Rock Paper Scissors Done...");
                ConsoleUtils.StartThread(StartRockPaperScissorsDone, PrintMenu);
            });
        }

        private void PrintMenu() {
            Console.WriteLine("Valid Commands:");
            Console.WriteLine("- 1, rockPaperScissors");
            Console.WriteLine("- 2, rockPaperScissorsDone");
        }

        private void StartRockPaperScissors() {
            new RockPaperScissors();
        }

        private void StartRockPaperScissorsDone() {
            new RockPaperScissors_Done();
        }

    }

}