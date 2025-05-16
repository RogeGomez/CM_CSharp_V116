using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2250_IEnumerable {

    public class CoroutineTest : MonoBehaviour {


        private void Start() {
            StartCoroutine(MyCoroutine());
        }

        private IEnumerator MyCoroutine() {
            Debug.Log("Before");
            yield return new WaitForSeconds(3);
            Debug.Log("After time");
        }


    }

}