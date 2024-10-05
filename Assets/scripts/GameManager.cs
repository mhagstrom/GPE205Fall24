using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//static is a reference to the class itself, not a game object or instance of the class
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private TankPawn[] players;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //this isn't a placeholder it is a self-reference
        }

        else
        {
            Destroy(gameObject);
            //Destroys the GameManager that this would make if one already exists
        }
    }

    private void Start()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("player");
        //avoid index out of bounds by ensuring array length of players matches findgameobjects
        players = new TankPawn[objects.Length];
    
    }
}
