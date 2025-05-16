using CodeMonkey.CSharpCourse.Companion;
using CodeMonkey.CSharpCourse.Interactive;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;
/*
namespace CodeMonkey.CSharpCourse.L2280_DesignPatterns {

    [InitializeOnLoad]
    public class ExerciseCompletionTester {


        private const string LECTURE_CODE = "2280";



        static ExerciseCompletionTester() {
            CodeMonkeyCompanion.OnCompilationFinished -= CodeMonkeyCompanion_OnCompilationFinished;
            CodeMonkeyCompanion.OnCompilationFinished += CodeMonkeyCompanion_OnCompilationFinished;
            CodeMonkeyCompanion.OnCompilerMessage -= CodeMonkeyCompanion_OnCompilerMessage;
            CodeMonkeyCompanion.OnCompilerMessage += CodeMonkeyCompanion_OnCompilerMessage;

            ExerciseSO.TryRemoveCompilationBlockers();
        }

        private static void CodeMonkeyCompanion_OnCompilerMessage(object sender, System.EventArgs e) {
            CompilerMessage compilerMessage = (CompilerMessage)sender;

            // Default
            CodeMonkeyCompanion.HandleCompilerMessage(compilerMessage);
        }

        private static void CodeMonkeyCompanion_OnCompilationFinished(object sender, System.EventArgs e) {
        }

        public static void ExerciseCompleted() {
            // Success! Exercise completed!
            CodeMonkeyInteractiveSO.SetState(CodeMonkeyInteractiveSO.GetActiveExerciseSO(), CodeMonkeyInteractiveSO.State.Completed);
        }

    }

}
*/