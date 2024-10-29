using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject pawnNotPresent;
    
    public void SpawnPawn()
    {
        if (pawnNotPresent == null)
        {
            pawnNotPresent.SetActive(true);
        }
    }
}
