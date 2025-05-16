using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class Money : MonoBehaviour, IGrabObject {


        private Vector3 spawnMoveDir;


        public void Setup(Vector3 spawnMoveDir) {
            this.spawnMoveDir = spawnMoveDir;
        }

        private void Update() {
            transform.position += spawnMoveDir * Time.deltaTime;

            float magnitude = spawnMoveDir.magnitude;
            magnitude -= magnitude * 10f * Time.deltaTime;
            spawnMoveDir = spawnMoveDir.normalized * magnitude;

            if (magnitude <= .1f) {
                this.enabled = false;
            }
        }

        public void DestroySelf() {
            Destroy(gameObject);
        }

        public bool HasInventoryItem() {
            return false;
        }

        public IInventoryItem GetInventoryItem() {
            return null;
        }

    }

}