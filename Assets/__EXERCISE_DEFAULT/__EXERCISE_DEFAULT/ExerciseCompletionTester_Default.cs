using CodeMonkey.CSharpCourse.Companion;
using CodeMonkey.CSharpCourse.Interactive;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;
/*
namespace CodeMonkey.CSharpCourse.L1090_Variables {

    [InitializeOnLoad]
    public class ExerciseCompletionTester {


        private const string LECTURE_CODE = "1090";



        static ExerciseCompletionTester() {
            CodeMonkeyCompanion.OnCompilationFinished -= CodeMonkeyCompanion_OnCompilationFinished;
            CodeMonkeyCompanion.OnCompilationFinished += CodeMonkeyCompanion_OnCompilationFinished;
            CodeMonkeyCompanion.OnCompilerMessage -= CodeMonkeyCompanion_OnCompilerMessage;
            CodeMonkeyCompanion.OnCompilerMessage += CodeMonkeyCompanion_OnCompilerMessage;

            ExerciseSO.TryRemoveCompilationBlockers();
        }

        private static void CodeMonkeyCompanion_OnCompilerMessage(object sender, System.EventArgs e) {
            CompilerMessage compilerMessage = (CompilerMessage)sender;

            if (compilerMessage.message.Contains("Int") || compilerMessage.message.Contains("INT")) {
                CodeMonkeyCompanion.SendCompanionMessage(
                    CodeMonkeyCompanion.MessageType.Error, 
                    "Something!"
                );
                return;
            }

            // Default
            CodeMonkeyCompanion.HandleCompilerMessage(compilerMessage);
        }

        private static void CodeMonkeyCompanion_OnCompilationFinished(object sender, System.EventArgs e) {
            if (CodeMonkeyCompanion.HasErrors()) {
                // There are still errors in the console
                Debug.Log("There are still errors in the console...");
                return;
            }

            if (!ExerciseUtils.TryGetLectureExerciseCSText(LECTURE_CODE, out string lectureText)) {
                CodeMonkeyCompanion.SendCompanionMessage(
                    CodeMonkeyCompanion.MessageType.Error,
                    "Cannot read Exercise.cs file! Did you move or rename it?"
                );
                return;
            }

            LectureSO lectureSO = LectureSO.GetLectureSO(LECTURE_CODE);
            string exerciseFilename = lectureSO.GetLectureFolderPath() + "Exercises/Exercise.cs";

            if (File.Exists(exerciseFilename)) {
                string exerciseFileText = File.ReadAllText(exerciseFilename);
                if (exerciseFileText.Contains("int speed")) {
                    // Success! Exercise completed!
                    ExerciseCompleted();
                } else {
                    // Exercise not complete, any common reason?
                    if (exerciseFileText.ToLower().Contains("speed")) {
                        CodeMonkeyCompanion.SendCompanionMessage(
                            CodeMonkeyCompanion.MessageType.Warning,
                            "Did you accidentally write '<b>Speed</b>' or something other than '<b>speed</b>'?\nRemember how code is <b>case sensitive!</b>"
                        );
                    }
                    if (exerciseFileText.Contains("int speed")) {
                        CodeMonkeyCompanion.SendCompanionMessage(
                            CodeMonkeyCompanion.MessageType.Info,
                            "Remember to assign the value <b>5</b> to the 'speed' variable"
                        );
                    }
                }
            } else {
                // File does not exist, did you accidentally delete it?
            }
        }

        public static void ExerciseCompleted() {
            // Success! Exercise completed!
            CodeMonkeyInteractiveSO.SetState(CodeMonkeyInteractiveSO.GetActiveExerciseSO(), CodeMonkeyInteractiveSO.State.Completed);
        }

    }

}
*/