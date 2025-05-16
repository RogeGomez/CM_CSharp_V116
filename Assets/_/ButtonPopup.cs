using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeMonkey.CSharpCourse.L1100_DataTypes {


    public class ButtonPopup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {


        [SerializeField] private float targetOverScale = 1.1f;
        [SerializeField] private float overRotation = 5f;


        private float targetScale = 1f;
        private float targetRotation = 0f;


        private void Update() {
            float rotateSpeed = 30f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Lerp(transform.eulerAngles.z, targetRotation, Time.deltaTime * rotateSpeed));

            float scaleSpeed = 5f;
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * targetScale, Time.deltaTime * scaleSpeed);
        }

        public void OnPointerEnter(PointerEventData eventData) {
            targetScale = targetOverScale;
            targetRotation = overRotation;
        }

        public void OnPointerExit(PointerEventData eventData) {
            targetScale = 1f;
            targetRotation = 0f;
        }


    }


}