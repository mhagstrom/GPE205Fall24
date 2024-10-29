using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerSpawner : Spawner
{
    
    //instantiate a tank for the player to control
    public void SpawnPlayer()
    {
        GameObject[] playerSpawns = GameObject.FindGameObjectsWithTag("PlayerSpawn");
        
        GameObject playerSpawn = playerSpawns[Random.Range(0, playerSpawns.Length)];
        
        GameManager.Instance.playerTank = Instantiate(GameManager.Instance.playerPrefab, playerSpawn.transform.position, playerSpawn.transform.rotation);
        
        
    }
}
