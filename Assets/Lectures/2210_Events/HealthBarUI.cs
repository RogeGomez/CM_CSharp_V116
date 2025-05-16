using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeMonkey.CSharpCourse.L2210_Events {

    public class HealthBarUI : MonoBehaviour {


        [SerializeField] private Tower tower;
        [SerializeField] private Image barImage; 


        private void Start() {
            tower.OnDamaged += Tower_OnDamaged;

            UpdateBar();
        }

        private void Tower_OnDamaged(object sender, System.EventArgs e) {
            UpdateBar();
        }

        private void UpdateBar() {
            barImage.fillAmount = tower.GetHealthNormalized();
        }

    }

}