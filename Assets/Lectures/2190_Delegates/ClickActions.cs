using CodeMonkey.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2190_Delegates {

    public class ClickActions : MonoBehaviour {


        [SerializeField] private Transform spritePrefab;
        [SerializeField] private Transform vfxPrefab;


        private Action clickAction;


        private void Start() {
            clickAction = SpawnChatBubble;
        }

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                clickAction();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                clickAction = SpawnChatBubble;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                clickAction = SpawnSprite;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                clickAction = SpawnParticleEffect;
            }
        }

        private void SpawnChatBubble() {
            ChatBubble.Create(null, UtilsClass.GetMouseWorldPosition(), ChatBubble.IconType.Happy, "Hi there!");
        }

        private void SpawnSprite() {
            Transform spriteTransform = Instantiate(spritePrefab, UtilsClass.GetMouseWorldPosition(), Quaternion.identity);
            Destroy(spriteTransform.gameObject, 2f);
        }

        private void SpawnParticleEffect() {
            Transform vfxTransform = Instantiate(vfxPrefab, UtilsClass.GetMouseWorldPosition(), Quaternion.identity);
            Destroy(vfxTransform.gameObject, 2f);
        }

    }

}