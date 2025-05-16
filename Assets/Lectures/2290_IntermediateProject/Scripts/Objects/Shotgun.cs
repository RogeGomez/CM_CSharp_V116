using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class Shotgun : Weapon {


        public override IInventoryItem.ItemType GetItemType() {
            return IInventoryItem.ItemType.Shotgun;
        }


        public override Sprite GetSprite() {
            return GameAssets.Instance.shotgunSprite;
        }

        public override void UseItem() {
            Vector3 shootPosition = UtilsClass.GetMouseWorldPosition();
            Player.Instance.Shoot(shootPosition);
            Player.Instance.Shoot(shootPosition + UtilsClass.GetRandomDir() * Random.Range(0f, 2f));
            Player.Instance.Shoot(shootPosition + UtilsClass.GetRandomDir() * Random.Range(0f, 2f));
            Player.Instance.Shoot(shootPosition + UtilsClass.GetRandomDir() * Random.Range(0f, 2f));
        }


    }

}