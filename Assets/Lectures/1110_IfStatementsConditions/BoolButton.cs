using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeMonkey.CSharpCourse.L1110_IfConditions {


    public class BoolButton : MonoBehaviour {


        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private bool state;


        private void Awake() {
            GetComponent<Button>()?.onClick.AddListener(() => {
                SetState(!state);
            });
            UpdateState();
        }

        private void UpdateState() {
            if (state) {
                textMesh.text = "true";
                textMesh.color = Color.green;
            } else {
                textMesh.text = "false";
                textMesh.color = UtilsClass.GetColorFromString("FF6F00");
            }
        }

        public void SetState(bool state) {
            this.state = state;
            UpdateState();
        }

        public bool GetState() {
            return state;
        }

    }


}