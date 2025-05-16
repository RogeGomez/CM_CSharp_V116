using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CodeMonkey.CSharpCourse.L1210_NamingRules {


    public class NamingRules {


        // Constants: UPPER_CASE_SNAKE_CASE
        public const int CONSTANT_FIELD = 56;

        // Properties: PascalCase
        public static GameManager Instance { get; private set; }

        // Events: PascalCase
        public event EventHandler OnSomethingHappened;

        // Fields: camelCase
        private float memberVariable;

        // Function Names: PascalCase
        private void MyFunction() {
            DoSomething(10f);
        }

        // Function Params: camelCase
        private void DoSomething(float time) {
            // Do something...
            memberVariable = time + Time.deltaTime;
            if (memberVariable > 0) {
                // Do something else...
                OnSomethingHappened?.Invoke(this, EventArgs.Empty);
            }
        }

    }

    public class GameManager {
    }

}