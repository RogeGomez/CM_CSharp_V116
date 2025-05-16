using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public interface IGrabObject {


        public bool HasInventoryItem();


        public IInventoryItem GetInventoryItem();


        public void DestroySelf();


    }
}