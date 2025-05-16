using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L1110_IfConditions {


    public class Player : MonoBehaviour {


        [SerializeField] private TextMeshProUGUI distanceTextMeshUI;
        [SerializeField] private Transform targetTransform;
        [SerializeField] private SpriteRenderer targetSpriteRenderer;


        private Vector3 targetPosition;


        private void Awake() {
            targetPosition = transform.position;
        }

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                targetPosition = UtilsClass.GetMouseWorldPosition();
            }

            float moveSpeed = 5f;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);

            float targetDistance = 4f;
            if (Vector3.Distance(transform.position, targetTransform.position) < targetDistance) {
                targetSpriteRenderer.color = Color.green;
            } else {
                targetSpriteRenderer.color = Color.white;
            }

            distanceTextMeshUI.text = "distance\n" + Vector3.Distance(transform.position, targetTransform.position).ToString("F2");
        }

    }


}