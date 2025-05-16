using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class InventorySlotUI : MonoBehaviour {


        [SerializeField] private Image itemImage;
        [SerializeField] private GameObject selectedGameObject;


        public void SetClickAction(Action clickAction) {
            GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(clickAction));
        }

        public void SetSelectedState(bool isSelected) {
            selectedGameObject.SetActive(isSelected);
        }

        public void SetItemSprite(Sprite sprite) {
            itemImage.sprite = sprite;

            itemImage.gameObject.SetActive(sprite != null);
        }

    }

}