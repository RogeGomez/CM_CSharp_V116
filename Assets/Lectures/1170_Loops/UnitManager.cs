using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L1170_Loops {

    public class UnitManager : MonoBehaviour {


        [SerializeField] private List<Unit> unitList;


        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                Vector3 targetPosition = UtilsClass.GetMouseWorldPosition();

                foreach (Unit unit in unitList) {
                    unit.SetTargetPosition(targetPosition);
                }
            }
        }

    }

}