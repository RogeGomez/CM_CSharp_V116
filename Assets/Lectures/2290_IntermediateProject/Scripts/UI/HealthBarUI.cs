using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class HealthBarUI : MonoBehaviour {


        [SerializeField] private HealthSystem healthSystem;
        [SerializeField] private Image barImage;


        private void Start() {
            healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;

            UpdateHealthBar();
        }

        private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e) {
            UpdateHealthBar();
        }

        private void UpdateHealthBar() {
            barImage.fillAmount = healthSystem.GetHealthNormalized();

            gameObject.SetActive(healthSystem.GetHealthNormalized() < 1f);
        }

    }

}