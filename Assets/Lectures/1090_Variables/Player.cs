using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L1090_Variables {


    public class Player : MonoBehaviour {

        [SerializeField] private int moveSpeed = 5;


        private float sin = 0f;


        private void Update() {
            transform.position = new Vector3(transform.position.x, Mathf.Sin(sin), transform.position.z);
            float slowdownMultiplier = .2f;
            sin += Time.deltaTime * moveSpeed * slowdownMultiplier;
        }

    }


}