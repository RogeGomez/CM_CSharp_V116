using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public interface IInventoryItem {


        public enum ItemType {
            Pistol,
            Shotgun,
            Potion,
        }

        
        public ItemType GetItemType();


        public Sprite GetSprite();


        public void UseItem();


    }

}