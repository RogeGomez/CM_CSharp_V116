using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2090_Dictionary {

    public class ResourceManager : MonoBehaviour {


        public enum ResourceType {
            Stone,
            Wood,
            Gold
        }


        [SerializeField] private Dictionary<ResourceType, int> resourceTypeAmountDictionary;


        [Serializable]
        public class ResourceTypeAmount {
            public ResourceType resourceType;
            public int amount;
        }



        [SerializeField] private List<ResourceTypeAmount> resourceTypeAmountList;


        private void Awake() {
            resourceTypeAmountDictionary = new Dictionary<ResourceType, int>();

            foreach (ResourceTypeAmount resourceTypeAmount in resourceTypeAmountList) {
                resourceTypeAmountDictionary[resourceTypeAmount.resourceType] = resourceTypeAmount.amount;
            }

            Debug.Log("Dictionary:");
            foreach (ResourceType resourceType in resourceTypeAmountDictionary.Keys) {
                Debug.Log(resourceType + ": " + resourceTypeAmountDictionary[resourceType]);
            }
        }


    }

}