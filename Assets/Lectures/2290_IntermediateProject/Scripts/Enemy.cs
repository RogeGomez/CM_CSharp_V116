using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class Enemy : MonoBehaviour, IAttackable {


        public static event EventHandler OnAnyDead;


        private HealthSystem healthSystem;


        private void Awake() {
            healthSystem = GetComponent<HealthSystem>();
        }

        private void Start() {
            healthSystem.OnDead += HealthSystem_OnDead;
        }

        private void Update() {
            Vector3 targetPosition = Player.Instance.transform.position;
            Vector3 moveDir = (targetPosition - transform.position).normalized;
            float moveSpeed = 1.5f;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }

        private void HealthSystem_OnDead(object sender, System.EventArgs e) {
            OnAnyDead?.Invoke(this, EventArgs.Empty);

            Destroy(gameObject);
        }

        public void Damage(int damageAmount) {
            healthSystem.Damage(damageAmount);
        }


    }
}