using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class Potion : IInventoryItem {


        public IInventoryItem.ItemType GetItemType() {
            return IInventoryItem.ItemType.Potion;
        }

        public Sprite GetSprite() {
            return GameAssets.Instance.potionSprite;
        }

        public void UseItem() {
            Player.Instance.GoSuper();
        }

    }

}