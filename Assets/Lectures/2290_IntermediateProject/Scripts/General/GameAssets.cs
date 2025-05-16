using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class GameAssets : MonoBehaviour {


        public static GameAssets Instance { get; private set; }


        private void Awake() {
            Instance = this;
        }



        public Sprite pistolSprite;
        public Sprite shotgunSprite;
        public Sprite potionSprite;


    }

}