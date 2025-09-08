using CodeMonkey.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMPro;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

namespace CodeMonkey.CSharpCourse.L1500_Projects {


    public class ProjectsConsole : MonoBehaviour {


        public static ProjectsConsole Instance { get; private set; }


        public event EventHandler OnWaitingForInput;
        public event EventHandler OnWriteLineQueueEmptied;
        public event EventHandler<OnWriteLineEventArgs> OnWriteLine;
        public class OnWriteLineEventArgs : EventArgs {
            public string line;
        }


        [SerializeField] private TextMeshProUGUI contentTextMesh;
        [SerializeField] private TMP_InputField inputTextMesh;
        [SerializeField] private RectTransform contentRectTransform;
        [SerializeField] private RectTransform scrollViewRectTransform;


        private Queue<string> writeLineQueue;
        private float writeLineQueueTimer = .1f;
        private float writeLineQueueTimerMax;
        private Dictionary<string, Action> commandActionDictionary;
        private bool isReadLine;
        private string lastReadLine;


        private void Awake() {
            Instance = this;

            writeLineQueue = new Queue<string>();
            writeLineQueueTimerMax = .1f;

            commandActionDictionary = new Dictionary<string, Action>();

            inputTextMesh.onSubmit.AddListener(InputSubmit);
        }

        private void Start() {
            inputTextMesh.ActivateInputField();
        }

        private void Update() {
            TryWriteLineDequeue();
        }

        public void InputSubmit(string submitString) {
            if (string.IsNullOrWhiteSpace(submitString)) {
                inputTextMesh.text = "";
                inputTextMesh.ActivateInputField();
                return;
            }

            WriteLine(submitString);

            if (isReadLine) {
                lastReadLine = submitString;
                isReadLine = false;
            } else {
                if (commandActionDictionary.ContainsKey(submitString)) {
                    commandActionDictionary[submitString]();
                } else {
                    WriteLine("Unknown Command...");
                }
            }

                inputTextMesh.text = "";
            inputTextMesh.ActivateInputField();
        }

        public void WriteLine(string line) {
            writeLineQueue.Enqueue(line);
        }

        private void TryWriteLineDequeue() {
            writeLineQueueTimer -= Time.deltaTime;
            if (writeLineQueueTimer > 0f) {
                return;
            }

            writeLineQueueTimer += writeLineQueueTimerMax;

            if (writeLineQueue.Count <= 0) {
                return;
            }

            string line = writeLineQueue.Dequeue();
            WriteLineInstant(line);

            if (writeLineQueue.Count == 0) {
                OnWriteLineQueueEmptied?.Invoke(this, EventArgs.Empty);
            }
        }

        public void WriteLineInstant(string line) {
            Debug.Log(line);
            contentTextMesh.text = contentTextMesh.text + "\n" + line;

            // Autosize
            float singleLineHeightOffset = 50f;
            contentRectTransform.sizeDelta = new Vector2(0, contentTextMesh.GetRenderedValues().y + singleLineHeightOffset);

            // Autoscroll down
            float positionOffset = contentRectTransform.sizeDelta.y - scrollViewRectTransform.sizeDelta.y;
            contentRectTransform.anchoredPosition = new Vector2(0, Mathf.Max(0f, positionOffset));

            OnWriteLine?.Invoke(this, new OnWriteLineEventArgs {
                line = line,
            });
        }

        public void SetWriteLineQueueTimerMax(float writeLineQueueTimerMax) {
            this.writeLineQueueTimerMax = writeLineQueueTimerMax;
        }

        public void RegisterCommand(string command, Action action) {
            commandActionDictionary[command] = action;
        }

        public void RegisterCommand(string[] commandArray, Action action) {
            foreach (string command in commandArray) {
                commandActionDictionary[command] = action;
            }
        }

        public void EnableIsReadLine() {
            isReadLine = true;
            lastReadLine = null;

            OnWaitingForInput?.Invoke(this, EventArgs.Empty);
        }

        public string GetLastReadLine() {
            return lastReadLine;
        }

        public void ClearLastReadLine() {
            lastReadLine = null;
        }

    }

    public static class Console {

        public static void WriteLine(string line) {
            ProjectsConsole.Instance.WriteLine(line);
        }

        public static void WriteLine(object line) {
            ProjectsConsole.Instance.WriteLine(line.ToString());
        }

        public static void WriteLineExpected(object expected, object got) {
            WriteLine($"Expected <color=#00ff00>{expected}</color>, got <color=#ffff00>{got}</color>...");
        }

        public static void WriteLineCorrect() {
            WriteLine($"<color=#00ff00>CORRECT!</color>");
        }

        public static void WriteLineIncorrect() {
            WriteLine($"<color=#aa1111>INCORRECT!</color>");
        }

        public static string ReadLine() {
            ProjectsConsole.Instance.EnableIsReadLine();
            while (true) {
                Thread.Sleep(100);
                string lastReadLine = ProjectsConsole.Instance.GetLastReadLine();
                if (lastReadLine != null) {
                    return lastReadLine;
                }
            }
        }

        public static int ReadLineInt() {
            ProjectsConsole.Instance.EnableIsReadLine();
            while (true) {
                Thread.Sleep(100);
                string lastReadLine = ProjectsConsole.Instance.GetLastReadLine();
                Debug.Log("ReadLineInt");
                if (lastReadLine != null) {
                    if (int.TryParse(lastReadLine, out int intValue)) {
                        return intValue;
                    } else {
                        ProjectsConsole.Instance.EnableIsReadLine();
                        WriteLine("Not a number, try again...");
                    }
                }
            }
        }

    }

    public static class ConsoleUtils {


        public static void StartThread(Action startAction, Action printMenu) {
            Thread workerThread = new Thread(() => startAction());
            workerThread.Start();
            FunctionPeriodic.Create(() => {
                if (!workerThread.IsAlive) {
                    Console.WriteLine("-");
                    printMenu();
                }
            }, () => {
                return !workerThread.IsAlive;
            }, .2f);
        }


    }


}