using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2290_IntermediateProject {

    public class GameManager : MonoBehaviour {


        public static GameManager Instance { get; private set; }


        [SerializeField] private Transform moneyPrefab;
        [SerializeField] private Transform enemyPrefab;
        [SerializeField] private Transform bombVfxPrefab;


        private float enemySpawnTimer;


        private void Awake() {
            Instance = this;
        }

        private void Start() {
            Enemy.OnAnyDead += Enemy_OnAnyDead;
            Bomb.OnAnyDead += Bomb_OnAnyDead;
        }

        private void Bomb_OnAnyDead(object sender, System.EventArgs e) {
            Bomb bomb = sender as Bomb;
            Transform bombTransform = Instantiate(bombVfxPrefab, bomb.transform.position, Quaternion.identity);
            UtilsClass.ShakeCamera(.5f, .1f);
        }

        private void Update() {
            HandleEnemySpawning();
        }

        private void Enemy_OnAnyDead(object sender, System.EventArgs e) {
            Enemy enemy = sender as Enemy;
            for (int i = 0; i < 3; i++) {
                Transform moneyTransform = Instantiate(moneyPrefab, enemy.transform.position, Quaternion.identity);
                Money money = moneyTransform.GetComponent<Money>();
                Vector3 randomDir = UtilsClass.GetRandomDir() * Random.Range(3f, 10f);
                money.Setup(randomDir);
            }
        }

        private void HandleEnemySpawning() {
            enemySpawnTimer -= Time.deltaTime;
            if (enemySpawnTimer <= 0f) {
                float enemySpawnTimerMax = 2.2f;
                enemySpawnTimer += enemySpawnTimerMax;

                SpawnEnemy();
            }
        }

        private void SpawnEnemy() {
            Vector3 spawnPosition = UtilsClass.GetRandomDir() * Random.Range(10f, 15f);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }

    }

}