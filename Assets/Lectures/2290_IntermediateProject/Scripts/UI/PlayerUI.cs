using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class PlayerUI : MonoBehaviour {


        [SerializeField] private TextMeshProUGUI moneyTextMesh;


        private void Start() {
            Player.Instance.OnMoneyAmountChanged += Player_OnMoneyAmountChanged;

            UpdateMoneyTextMesh();
        }

        private void Player_OnMoneyAmountChanged(object sender, System.EventArgs e) {
            UpdateMoneyTextMesh();
        }

        private void UpdateMoneyTextMesh() {
            moneyTextMesh.text = Player.Instance.GetMoneyAmount().ToString();
        }

    }

}