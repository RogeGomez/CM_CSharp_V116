using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeMonkey.CSharpCourse.L1120_Switch {

    public class SwitchLecture : MonoBehaviour {


        private readonly Vector2 defaultPosition = new Vector2(-847, 96);
        private readonly Vector2 caseCodeMonkeyPosition = new Vector2(-847, -26);
        private readonly Vector2 caseIronManPosition = new Vector2(-847, -155);
        private readonly Vector2 caseBlackWidowPosition = new Vector2(-847, -280);


        [SerializeField] private TextMeshProUGUI nameTextMesh;
        [SerializeField] private Image whiteOutlineImage;
        [SerializeField] private Button codeMonkeyButton;
        [SerializeField] private Button ironManButton;
        [SerializeField] private Button blackWidowButton;
        [SerializeField] private Button spiderManButton;
        [SerializeField] private RectTransform arrowRectTransform;


        private new string name;


        private void Awake() {
            codeMonkeyButton.onClick.AddListener(() => {
                SetName("Code Monkey");
            });
            ironManButton.onClick.AddListener(() => {
                SetName("Iron Man");
            });
            blackWidowButton.onClick.AddListener(() => {
                SetName("Black Widow");
            });
            spiderManButton.onClick.AddListener(() => {
                SetName("Spider-Man");
            });
        }

        private void Start() {
            SetName("Code Monkey");
        }

        public void SetName(string name) {
            this.name = name;

            nameTextMesh.text = $"string name = \"{name}\";";

            switch (name) {
                default:
                    ChangeOutlineColor(Color.black);
                    arrowRectTransform.anchoredPosition = defaultPosition;
                    break;
                case "Code Monkey":
                    ChangeOutlineColor(Color.white);
                    arrowRectTransform.anchoredPosition = caseCodeMonkeyPosition;
                    break;
                case "Iron Man":
                    ChangeOutlineColor(Color.yellow);
                    arrowRectTransform.anchoredPosition = caseIronManPosition;
                    break;
                case "Black Widow":
                    ChangeOutlineColor(Color.red);
                    arrowRectTransform.anchoredPosition = caseBlackWidowPosition;
                    break;
            }
        }

        private void ChangeOutlineColor(Color color) {
            whiteOutlineImage.color = color;
        }

        public string GetName() {
            return name;
        }


    }

}