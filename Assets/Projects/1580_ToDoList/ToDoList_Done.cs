using CodeMonkey.CSharpCourse.L1500_Projects;
using System.Collections.Generic;

namespace CodeMonkey.CSharpCourse.L1580_ToDoList {

    public class ToDoList_Done {


        private List<string> taskList;
        private List<bool> taskCompletionList;

        /* ** ToDo List **
         * 
         * Display a list of Tasks
         * Implement the ability to Add Tasks to the list
         * And the ability to Complete Tasks
         * 
         * Implement a menu to choose the action
         * 
         * Hint: The List<string> type is great for storing a collection that grows
         * */
        public ToDoList_Done() {
            taskList = new List<string>();
            taskCompletionList = new List<bool>();

            while (true) {
                PrintTasks();
                PrintMenu();

                string menuOption = Console.ReadLine();

                switch (menuOption) {
                    case "addTask":
                        Console.WriteLine("Task name:");
                        string taskName = Console.ReadLine();
                        taskList.Add(taskName);
                        taskCompletionList.Add(false);
                        break;

                    case "completeTask":
                        Console.WriteLine("Task List:");
                        for (int i = 0; i < taskList.Count; i++) {
                            string task = taskList[i];
                            string completedString = " ";
                            if (taskCompletionList[i]) {
                                completedString = "x";
                            }
                            Console.WriteLine("[" + i + "] "+ "[" + completedString + "] " + task);
                        }

                        int index = Console.ReadLineInt();
                        if (index >= 0 && index < taskList.Count) {
                            Console.WriteLine("Completed task:" + taskList[index]);
                            taskCompletionList[index] = true;
                        } else {
                            Console.WriteLine("Invalid index!");
                        }
                        break;

                    case "exit":
                        return;
                }

                Console.WriteLine("-");
            }
        }

        private void PrintTasks() {
            Console.WriteLine("Task List:");
            for (int i=0; i<taskList.Count; i++) {
                string task = taskList[i];
                string completedString = " ";
                if (taskCompletionList[i]) {
                    completedString = "x";
                }
                Console.WriteLine("[" + completedString + "] " + task);
            }
        }

        private void PrintMenu() {
            Console.WriteLine("Menu:");
            Console.WriteLine("- addTask");
            Console.WriteLine("- completeTask");
            Console.WriteLine("- exit");
        }

    }

}