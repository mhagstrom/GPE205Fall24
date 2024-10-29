using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


//static is a reference to the class itself, not a game object or instance of the class
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    //spawns
    public PlayerSpawner playerSpawner;
    public EnemySpawner enemySpawner;
    
    /*  this will be for aicontroller
    public GameObject enemyTypeQuick;
    public GameObject enemyTypeStrong;
    public GameObject enemyTypeNormal;
    public GameObject enemyTypeBoss;
    */
    
    public Transform[] SpawnTransform;
    
    //These will be spawned by the spawners
    [HideInInspector]public GameObject playerTank;
    [HideInInspector]public GameObject[] enemyTank;
    
    public int enemyCount = 4;
    
    private TankPawn[] players; //this is for splitscreen later
    //make sure gamemanager is aware of tanks spawned and killed
    private List<TankPawn> enemies;
    
    //gameState
    public int Lives { get; private set; } = 3;
    public int Score { get; private set; } = 0;
    //making lives and score properties allows the values to be displayed to the player without exposing them to edits outside of the game manager. aka getters and setters
    //properties lowercase

    //reference to the prefab used to spawn tanks, will be added to the tank spawner too
    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    [SerializeField] private PlayerController playerOneController;

    [SerializeField] private GameObject aiControllerPrefab;
    //player one static should be replaced with something in game manager to generate player controllers from inherited template based on number of players
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //this isn't a placeholder it is a self-reference
            DontDestroyOnLoad(gameObject);
        }
        
        else
        {
            Destroy(gameObject);
            //Destroys the GameManager that this would make if one already exists
        }
        
        
        
    }

    private void Start()
    {
        enemyTank = new GameObject[enemyCount];
        
        playerSpawner.SpawnPlayer();
        enemySpawner.SpawnEnemies();
        
        //assign the tank to the player controller
        TankPawn playerTankPawn = playerTank.GetComponent<TankPawn>();
        playerOneController.TakeControl(playerTankPawn);
        
        /*instatiate enemy tanks
        GameObject enemyTank = Instantiate(enemyTypeNormal);
        GameObject enemyTank2 = Instantiate(enemyTypeQuick);
        GameObject enemyTank3 = Instantiate(enemyTypeStrong);
        GameObject enemyTank4 = Instantiate(enemyTypeBoss);
        newAIController = Instantiate(aiControllerPrefab) as GameObject;
        */
        
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

    /*
     public void SpawnEnemy()
    {
        int random = Random.Range(0, SpawnTransform.Length);
        enemyTypeNormal.SetActive(true);
        AIControllerPrefab.SetActive(true);
        
        GameObject enemy = Instantiate(enemyTypeNormal, SpawnTransform[random].position, Quaternion.identity);
        GameObject newAIController = Instantiate(aiControllerPrefab) as GameObject;
        
        Controller newController = newAIController.GetComponent<AIController>();
        
        Pawn newPawn = enemy.GetComponent<Pawn>();
        
        newController.pawn = newEnemyPawn;
    }
    */
}
