using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2140_Struct {

    public class LectureStructs : MonoBehaviour {




        private void Start() {
            Player player = new Player() {
                a = 2,
            };
            Debug.Log(player);
            Debug.Log(player.a);
        }

        public struct Player {

            public int a;

            public Player(int a) {
                this.a = a;
            }

        }

    }

}














/*
        private void Start() {

            PlayerStruct playerStruct = new PlayerStruct();
            playerStruct.a = 1;
            PlayerClass playerClass = new PlayerClass();
            playerClass.a = 1;

            TestFunctionStruct(playerStruct);
            TestFunctionClass(playerClass);

            Debug.Log("playerStruct " + playerStruct.a);
            Debug.Log("playerClass " + playerClass.a);
        }

        private void TestFunctionStruct(PlayerStruct playerStruct) {
            playerStruct.a = 2;
        }

        private void TestFunctionClass(PlayerClass playerClass) {
            playerClass.a = 2;
        }

        public struct PlayerStruct {
            public int a;
        }

        public class PlayerClass {
            public int a;
        }
 * */