using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L1110_IfConditions {

    
    public class TruthTable : MonoBehaviour {


        [SerializeField] private BoolButton andInputABoolButton;
        [SerializeField] private BoolButton andInputBBoolButton;
        [SerializeField] private BoolButton andOutputBoolButton;
        [SerializeField] private BoolButton orInputABoolButton;
        [SerializeField] private BoolButton orInputBBoolButton;
        [SerializeField] private BoolButton orOutputBoolButton;
        [SerializeField] private BoolButton notInputBoolButton;
        [SerializeField] private BoolButton notOutputBoolButton;


        private void Update() {
            andOutputBoolButton.SetState(andInputABoolButton.GetState() && andInputBBoolButton.GetState());
            orOutputBoolButton.SetState(orInputABoolButton.GetState() || orInputBBoolButton.GetState());
            notOutputBoolButton.SetState(!notInputBoolButton.GetState());
        }

    }


}
