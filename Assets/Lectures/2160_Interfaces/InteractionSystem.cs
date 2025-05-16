using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2160_Interfaces {

    public class InteractionSystem : MonoBehaviour {


        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

                Collider2D hitCollider2D = Physics2D.OverlapPoint(mousePosition);
                if (hitCollider2D != null) {
                    // Clicked on something
                    if (hitCollider2D.TryGetComponent(out IInteractable interactable)) {
                        interactable.Interact();
                    }
                }
            }
        }
    }

}