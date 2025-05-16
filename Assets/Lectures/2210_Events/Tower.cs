using CodeMonkey.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2210_Events {

    public class Tower : MonoBehaviour {


        public event EventHandler OnDamaged;


        [SerializeField] private Transform vfxPrefab;


        private int healthAmount = 20;
        private int healthAmountMax = 20;


        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                Damage();
                UtilsClass.ShakeCamera(.1f, .1f);
                Instantiate(vfxPrefab, UtilsClass.GetMouseWorldPosition(), Quaternion.identity);
            }
        }

        private void Damage() {
            healthAmount--;
            OnDamaged?.Invoke(this, EventArgs.Empty);
        }

        public float GetHealthNormalized() {
            return (float)healthAmount / healthAmountMax;
        }

    }

}