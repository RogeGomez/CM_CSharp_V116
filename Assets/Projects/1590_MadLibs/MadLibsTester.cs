using CodeMonkey.CSharpCourse.L1500_Projects;
using CodeMonkey.Utils;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace CodeMonkey.CSharpCourse.L1590_MadLibs {

    public class MadLibsTester : MonoBehaviour {



        private void Start() {
            PrintMenu();

            ProjectsConsole.Instance.RegisterCommand(new string[] { "1", "madLibs" }, () => {
                Console.WriteLine("Starting MadLibs...");
                ConsoleUtils.StartThread(StartMadLibs, PrintMenu);
            });

            ProjectsConsole.Instance.RegisterCommand(new string[] { "2", "madLibsDone" }, () => {
                Console.WriteLine("Starting MadLibs Done...");
                ConsoleUtils.StartThread(StartMadLibsDone, PrintMenu);
            });
        }

        private void PrintMenu() {
            Console.WriteLine("Valid Commands:");
            Console.WriteLine("- 1, madLibs");
            Console.WriteLine("- 2, madLibsDone");
        }

        private void StartMadLibs() {
            new MadLibs();
        }

        private void StartMadLibsDone() {
            new MadLibs_Done();
        }

    }

}