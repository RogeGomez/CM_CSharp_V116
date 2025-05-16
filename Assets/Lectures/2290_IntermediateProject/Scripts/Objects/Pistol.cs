using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class Pistol : Weapon {


        public override IInventoryItem.ItemType GetItemType() {
            return IInventoryItem.ItemType.Pistol;
        }

        public override Sprite GetSprite() {
            return GameAssets.Instance.pistolSprite;
        }

        public override void UseItem() {
            Vector3 shootPosition = UtilsClass.GetMouseWorldPosition();
            Player.Instance.Shoot(shootPosition);
        }

    }

}