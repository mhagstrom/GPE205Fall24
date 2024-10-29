using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    //instantiate a tank for the enemy to control
    public void SpawnEnemies()
    {
        for (int i = 0; i < GameManager.Instance.enemyCount; i++)
        {
            GameObject[] enemySpawns = GameObject.FindGameObjectsWithTag("EnemySpawn");
            // [i] means one per spawn, make sure there are 4 spawns, later this can be random with a check for spawn already used
            GameObject enemySpawn = enemySpawns[i];

            GameManager.Instance.enemyTank[i] = Instantiate(GameManager.Instance.enemyPrefab, enemySpawn.transform.position,
                enemySpawn.transform.rotation);
        }

    }
}
