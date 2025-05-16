using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L1100_DataTypes {


    public class DataValue : MonoBehaviour {


        public enum DataType {
            String,
            Int,
            Bool,
            Float,
        }


        [SerializeField] private DataType dataType;


        private bool isMovingToTarget;
        private RectTransform rectTransform;
        private Vector2 targetAnchoredPosition;


        private void Awake() {
            rectTransform = GetComponent<RectTransform>();
        }

        private void Update() {
            if (!isMovingToTarget) {
                return;
            }

            float moveSpeed = 20f;
            rectTransform.anchoredPosition += (targetAnchoredPosition - rectTransform.anchoredPosition) * moveSpeed * Time.deltaTime;

            float maxDistance = 10f;
            if (Vector3.Distance(rectTransform.anchoredPosition, targetAnchoredPosition) < maxDistance) {
                Destroy(gameObject);
            }
        }

        public void SetTargetAnchoredPosition(Vector2 targetAnchoredPosition) {
            this.targetAnchoredPosition = targetAnchoredPosition;
            isMovingToTarget = true;
        }

        public DataType GetDataType() {
            return dataType;
        }

    }

}