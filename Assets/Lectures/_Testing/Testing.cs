using CodeMonkey.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Testing : MonoBehaviour {



    private float timer;

    private void Start() {
        StartCoroutine(CoroutineFunction());
    }

    private void Update() {
        timer -= Time.deltaTime;
        if (timer < 0) {
            timer += 1f;
            // Do logic
        }
    }


    public IEnumerator CoroutineFunction() {
        yield return null;
        Debug.Log("asdf");
    }

}

