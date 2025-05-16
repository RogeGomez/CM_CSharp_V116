using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class HoldingObjectVisual : MonoBehaviour {


        [SerializeField] private Inventory inventory;
        [SerializeField] private Transform pistolPrefab;
        [SerializeField] private Transform shotgunPrefab;
        [SerializeField] private Transform potionPrefab;


        private void Start() {
            inventory.OnSelectedIndexChanged += Inventory_OnSelectedIndexChanged;

            UpdateVisual();
        }

        private void Inventory_OnSelectedIndexChanged(object sender, System.EventArgs e) {
            UpdateVisual();
        }

        private void UpdateVisual() {
            IInventoryItem selectedInventoryItem = inventory.GetSelectedItem();

            UtilsClass.DestroyChildren(transform);

            if (selectedInventoryItem != null) {
                switch (selectedInventoryItem.GetItemType()) {
                    case IInventoryItem.ItemType.Pistol:
                        Instantiate(pistolPrefab, transform);
                        break;
                    case IInventoryItem.ItemType.Shotgun:
                        Instantiate(shotgunPrefab, transform);
                        break;
                    case IInventoryItem.ItemType.Potion:
                        Instantiate(potionPrefab, transform);
                        break;
                }
            }
        }

    }

}