﻿using UnityEngine;
using UnityEngine.Networking;

namespace ml6468.A07{
    public class EnemySpawner : NetworkBehaviour
    {
        // this is attached to Enemy Spawner so that enemy can randomly spawn.
        public GameObject enemyPrefab;
        public int numberOfEnemies;

        public override void OnStartServer()
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                var spawnPosition = new Vector3(
                    Random.Range(-8.0f, 8.0f),
                    0.0f,
                    Random.Range(-8.0f, 8.0f));

                var spawnRotation = Quaternion.Euler(
                    0.0f,
                    Random.Range(0, 180),
                    0.0f);

                var enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, spawnRotation);
                NetworkServer.Spawn(enemy);
            }
        }
    }
}
