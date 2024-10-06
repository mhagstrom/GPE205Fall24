using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//static is a reference to the class itself, not a game object or instance of the class
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private TankPawn[] players;
    //make sure gamemanager is aware of tanks spawned and killed
    private List<TankPawn> enemies;
    
    //gameState
    public int lives { get; private set; } = 3;
    public int score { get; private set; } = 0;
    //making lives and score properties allows the values to be displayed to the player without exposing them to edits outside of the game manager aka getters and setters
    //properties lowercase

    //reference to the prefab used to spawn tanks, will be added to the tank spawner too
    [SerializeField] private TankPawn tankPrefab;
    [SerializeField] private PlayerController playerOneController;
    //player one static should be replaced with something in game manager to generate player controllers from inherited template based on number of players
    
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
        //instantiate a tank for the player to control
        TankPawn playerTank = Instantiate(tankPrefab);
        //assign the tank to the player controller
        playerOneController.TakeControl(playerTank);
        
        FindAllPlayers();
    }

    private void FindAllPlayers()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");
        
        if (objects.Length == 0)
        {
            Debug.LogError("No Players Found!");
        }
        
        //avoid index out of bounds by ensuring array length of players matches findgameobjects
        players = new TankPawn[objects.Length];

        for (int i = 0; i < objects.Length; i++)
        {
            //grabs gameobject instances of tankpawn and copies them to the player array
            players[i] = objects[i].GetComponent<TankPawn>();
        }
    }

    //these functions allow me to add and remove enemies without giving other scripts direct control over the List
    public void RegisterEnemy(TankPawn enemy)
    {
        if (enemies.Contains(enemy))
        {
            //List already has this enemy registered
            return;
        }

        enemies.Add(enemy);
    }

    public void UnregisterEnemy(TankPawn enemy)
    {
        if (!enemies.Contains(enemy))
        {
            return;
        }

        enemies.Remove(enemy);
    }
}
