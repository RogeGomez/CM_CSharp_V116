using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2270_SingletonPattern {

    public class GameManager : MonoBehaviour {


        public static GameManager Instance { get; private set; }


        private void Awake() {
            if (Instance != null) {
                Debug.LogError("Instance already exists!");
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }



    }

}