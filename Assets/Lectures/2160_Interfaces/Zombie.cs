using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2160_Interfaces {

    public class Zombie : MonoBehaviour, IInteractable {

        public void Interact() {
            ChatBubble.Create(transform, new Vector3(.75f, .75f), ChatBubble.IconType.Angry, "BRAINS!");
        }

    }

}