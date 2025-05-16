using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class HealthSystem : MonoBehaviour {


        public event EventHandler OnHealthChanged;
        public event EventHandler OnDead;

        
        private int healthAmount;
        private int healthAmountMax = 100;

        private void Awake() {
            healthAmount = healthAmountMax;
        }

        public void Damage(int damageAmount) {
            healthAmount -= damageAmount;
            if (healthAmount <= 0) {
                healthAmount = 0;
                OnDead?.Invoke(this, EventArgs.Empty);
            }
            OnHealthChanged?.Invoke(this, EventArgs.Empty);
        }

        public float GetHealthNormalized() {
            return (float)healthAmount / healthAmountMax;
        }

    }

}