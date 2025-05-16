using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class InventoryUI : MonoBehaviour {


        [SerializeField] private Inventory inventory;
        [SerializeField] private List<InventorySlotUI> inventorySlotUIList;


        private void Start() {
            inventory.OnItemListChanged += Inventory_OnItemListChanged;
            inventory.OnSelectedIndexChanged += Inventory_OnSelectedIndexChanged;

            inventorySlotUIList[0].SetClickAction(() => {
                inventory.SetSelectedIndex(0);
            });
            inventorySlotUIList[1].SetClickAction(() => {
                inventory.SetSelectedIndex(1);
            });
            inventorySlotUIList[2].SetClickAction(() => {
                inventory.SetSelectedIndex(2);
            });

            UpdateItemList();
            UpdateSelected();
        }

        private void Inventory_OnItemListChanged(object sender, System.EventArgs e) {
            UpdateItemList();
            UpdateSelected();
        }

        private void Inventory_OnSelectedIndexChanged(object sender, System.EventArgs e) {
            UpdateSelected();
        }

        private void UpdateItemList() {
            foreach (InventorySlotUI inventorySlotUI in inventorySlotUIList) {
                inventorySlotUI.SetSelectedState(false);
                inventorySlotUI.SetItemSprite(null);
            }

            for (int i = 0; i < inventory.GetInventoryItemList().Count; i++) {
                IInventoryItem inventoryItem = inventory.GetInventoryItemList()[i];
                inventorySlotUIList[i].SetItemSprite(inventoryItem.GetSprite());
            }
        }

        private void UpdateSelected() {
            // Deselect all
            foreach (InventorySlotUI inventorySlotUI in inventorySlotUIList) {
                inventorySlotUI.SetSelectedState(false);
            }

            // Select just one
            inventorySlotUIList[inventory.GetSelectedIndex()].SetSelectedState(true);
        }

    }

}