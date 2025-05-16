using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class PotionObject : MonoBehaviour, IGrabObject {

        public void DestroySelf() {
            Destroy(gameObject);
        }

        public IInventoryItem GetInventoryItem() {
            return new Potion();
        }

        public bool HasInventoryItem() {
            return true;
        }

    }
}