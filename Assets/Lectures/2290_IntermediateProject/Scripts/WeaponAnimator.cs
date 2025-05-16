using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class WeaponAnimator : MonoBehaviour {


        private const string SHOOT = "Shoot";


        [SerializeField] private Transform shootBulletRayPrefab;
        [SerializeField] private Transform shootPointTransform;
        [SerializeField] private Transform vfxPrefab;


        private Animator animator;


        private void Awake() {
            animator = GetComponent<Animator>();
        }

        private void Start() {
            Player.Instance.OnShoot += Player_OnShoot;
        }

        private void Player_OnShoot(object sender, Player.OnShootEventArgs e) {
            animator.SetTrigger(SHOOT);

            Instantiate(vfxPrefab, e.shootPoint, Quaternion.identity);

            Vector3 shootDir = (e.shootPoint - shootPointTransform.position).normalized;
            float eulerZ = UtilsClass.GetAngleFromVectorFloat(shootDir);
            Transform shootBulletRayTransform = Instantiate(shootBulletRayPrefab, shootPointTransform.position, Quaternion.Euler(0, 0, eulerZ));
            shootBulletRayTransform.localScale = new Vector3(Vector3.Distance(shootPointTransform.position, e.shootPoint), 1, 1);
            Destroy(shootBulletRayTransform.gameObject, .05f);
        }

        private void OnDestroy() {
            Player.Instance.OnShoot -= Player_OnShoot;
        }

    }

}