using CodeMonkey.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {


    public class Player : MonoBehaviour {


        public static Player Instance { get; private set; }


        private const float MOVE_SPEED = 5f;
        private const int DAMAGE_AMOUNT = 35;
        private const float SUPER_TIMER_MAX = 5f;



        public class OnShootEventArgs : EventArgs {
            public Vector3 shootPoint;
        }
        public event EventHandler<OnShootEventArgs> OnShoot;

        public class OnGrabbedObjectEventArgs : EventArgs {
            public IGrabObject grabObject;
        }
        public event EventHandler<OnGrabbedObjectEventArgs> OnGrabbedObject;

        public event EventHandler OnMoneyAmountChanged;


        [SerializeField] private LayerMask shootingLayerMask;
        [SerializeField] private Transform holdingObjectTransform;
        [SerializeField] private Transform superVfxTransform;


        private int moneyAmount;
        private Inventory inventory;
        private float superTimer;


        private void Awake() {
            Instance = this;

            inventory = GetComponent<Inventory>();

            OnGrabbedObject += Player_OnGrabbedObject;
        }

        private void Player_OnGrabbedObject(object sender, OnGrabbedObjectEventArgs e) {
            if (e.grabObject is Money) {
                moneyAmount++;

                OnMoneyAmountChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void Update() {
            HandleMovement();
            HandleObjectRotation();
            HandleItems();
            HandleSuper();
        }

        private void HandleObjectRotation() {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            float angleY = UtilsClass.GetAngleFromVectorFloat(mouseWorldPosition - transform.position);
            holdingObjectTransform.eulerAngles = new Vector3(0, 0, angleY);
        }

        private void HandleItems() {
            if (Input.GetMouseButtonDown(0) && !UtilsClass.IsPointerOverUI()) {
                IInventoryItem selectedInventoryItem = inventory.GetSelectedItem();
                if (selectedInventoryItem != null) {
                    selectedInventoryItem.UseItem();
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                inventory.SetSelectedIndex(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                inventory.SetSelectedIndex(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                inventory.SetSelectedIndex(2);
            }
        }

        public void Shoot(Vector3 shootPosition) {
            Vector3 shootDir = (shootPosition - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, shootPosition);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, shootDir, distance, shootingLayerMask);
            if (raycastHit2D.collider != null) {
                shootPosition = raycastHit2D.point;

                if (raycastHit2D.transform.TryGetComponent(out IAttackable attackable)) {
                    attackable.Damage(DAMAGE_AMOUNT);
                }
            }

            OnShoot?.Invoke(this, new OnShootEventArgs {
                shootPoint = shootPosition,
            });
        }

        private void HandleMovement() {
            Vector3 moveDir = Vector3.zero;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                moveDir.y = +1;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                moveDir.y = -1;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                moveDir.x = -1;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                moveDir.x = +1;
            }

            float isSuperMultiplier = 1f;
            if (IsSuper()) {
                isSuperMultiplier = 2f;
            }
            transform.position += moveDir * MOVE_SPEED * isSuperMultiplier * Time.deltaTime;
        }

        private void HandleSuper() {
            if (IsSuper()) {
                superTimer -= Time.deltaTime;

                if (!IsSuper()) {
                    // Super ended
                    superVfxTransform.gameObject.SetActive(false);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collider2D) {
            if (collider2D.TryGetComponent(out IGrabObject grabObject)) {
                OnGrabbedObject?.Invoke(this, new OnGrabbedObjectEventArgs {
                    grabObject = grabObject,
                });

                if (grabObject.HasInventoryItem()) {
                    if (inventory.CanAddItem()) {
                        // Add item to inventory
                        inventory.AddObject(grabObject.GetInventoryItem());

                        grabObject.DestroySelf();
                    } else {
                        // Cannot add, don't destroy
                    }
                } else {
                    // Object does not have an inventory item
                    grabObject.DestroySelf();
                }
            }
        }

        public int GetMoneyAmount() {
            return moneyAmount;
        }

        public void GoSuper() {
            superTimer = SUPER_TIMER_MAX;

            superVfxTransform.gameObject.SetActive(true);
        }

        public bool IsSuper() {
            return superTimer > 0f;
        }

    }

}