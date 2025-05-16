using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {


    public class Inventory : MonoBehaviour {


        private const int CAPACITY = 3;


        public event EventHandler OnSelectedIndexChanged;
        public event EventHandler OnItemListChanged;


        private List<IInventoryItem> inventoryItemList;
        private int selectedIndex;


        private void Awake() {
            inventoryItemList = new List<IInventoryItem>();
        }

        public bool CanAddItem() {
            return inventoryItemList.Count < CAPACITY;
        }

        public void AddObject(IInventoryItem inventoryItem) {
            if (!CanAddItem()) {
                // Cannot add item! Inventory full!
                throw new InventoryFullException();
            }
            inventoryItemList.Add(inventoryItem);

            OnItemListChanged?.Invoke(this, EventArgs.Empty);

            if (inventoryItemList.Count == 1) {
                // Added first item, select it automatically
                SetSelectedIndex(0);
            }
        }

        public void SetSelectedIndex(int selectedIndex) {
            this.selectedIndex = selectedIndex;

            OnSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        public int GetSelectedIndex() {
            return selectedIndex;
        }

        public List<IInventoryItem> GetInventoryItemList() {
            return inventoryItemList;
        }

        public IInventoryItem GetSelectedItem() {
            if (selectedIndex < inventoryItemList.Count) {
                return inventoryItemList[selectedIndex];
            } else {
                return null;
            }
        }

        public class InventoryFullException : Exception { }

    }


}