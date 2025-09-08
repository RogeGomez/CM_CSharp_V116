using CodeMonkey.CSharpCourse.L1500_Projects;
using CodeMonkey.Utils;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace CodeMonkey.CSharpCourse.L1580_ToDoList {

    public class ToDoListTester : MonoBehaviour {



        private void Start() {
            PrintMenu();

            ProjectsConsole.Instance.RegisterCommand(new string[] { "1", "toDoList" }, () => {
                Console.WriteLine("Starting ToDoList...");
                ConsoleUtils.StartThread(StartToDoList, PrintMenu);
            });

            ProjectsConsole.Instance.RegisterCommand(new string[] { "2", "toDoListDone" }, () => {
                Console.WriteLine("Starting ToDoList Done...");
                ConsoleUtils.StartThread(StartToDoListDone, PrintMenu);
            });
        }

        private void PrintMenu() {
            Console.WriteLine("Valid Commands:");
            Console.WriteLine("- 1, toDoList");
            Console.WriteLine("- 2, toDoListDone");
        }

        private void StartToDoList() {
            new ToDoList();
        }

        private void StartToDoListDone() {
            new ToDoList_Done();
        }

    }

}