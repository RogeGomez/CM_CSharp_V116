using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2160_Interfaces {

    public class Building : MonoBehaviour, IInteractable {

        public void Interact() {
            ChatBubble.Create(transform, new Vector3(1, 1), ChatBubble.IconType.Happy, "*knock knock*");
        }

    }

}