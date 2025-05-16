using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L1170_Loops {

    public class Unit : MonoBehaviour {


        private Rigidbody2D unitRigidbody2D;
        private Vector3 targetPosition;
        private bool isMoving;


        private void Awake() {
            unitRigidbody2D = GetComponent<Rigidbody2D>();
            targetPosition = transform.position;
        }

        private void Update() {
            if (isMoving) {
                float reachedDistance = 3f;
                if (Vector3.Distance(transform.position, targetPosition) > reachedDistance) {
                    Vector3 moveDir = (targetPosition - transform.position).normalized;
                    float moveSpeed = 5f;
                    unitRigidbody2D.velocity = moveDir * moveSpeed;
                } else {
                    // Reached position
                    isMoving = false;
                }
            }
        }

        public void SetTargetPosition(Vector3 targetPosition) {
            this.targetPosition = targetPosition;
            isMoving = true;
        }

    }

}