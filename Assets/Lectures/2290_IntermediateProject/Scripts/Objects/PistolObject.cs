using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class PistolObject : MonoBehaviour, IGrabObject {

        public void DestroySelf() {
            Destroy(gameObject);
        }

        public IInventoryItem GetInventoryItem() {
            return new Pistol();
        }

        public bool HasInventoryItem() {
            return true;
        }

    }

}