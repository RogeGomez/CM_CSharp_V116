using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {


    public abstract class Weapon : IInventoryItem {


        public abstract IInventoryItem.ItemType GetItemType();


        public abstract Sprite GetSprite();


        public abstract void UseItem();


    }
}