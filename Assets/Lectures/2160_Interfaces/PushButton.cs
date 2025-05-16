using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2160_Interfaces {

    public class PushButton : MonoBehaviour, IInteractable {

        public void Interact() {
            ChatBubble.Create(transform, new Vector3(.5f, .5f), ChatBubble.IconType.Neutral, "*click*");
        }

    }

}
