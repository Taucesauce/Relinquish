using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    List<Enemy> currentEnemies;
    public List<Enemy> CurrentEnemies { get { return currentEnemies; } }

    [SerializeField]
    Player playerRef;

    //Singleton Pattern
    //Private instance of manager
    private static EnemySpawner enemySpawner;

    //Publicly accessible instance of manager
    //Gets the private instance or if the private instance doesn't exist yet, makes one.
    public static EnemySpawner instance {
        get {
            if (!enemySpawner) {
                enemySpawner = FindObjectOfType(typeof(EnemySpawner)) as EnemySpawner;

                if (!enemySpawner) {
                    Debug.LogError("No active EventManager script found.");
                }
                else {
                    enemySpawner.Init();
                }
            }

            return enemySpawner;
        }
    }

    void Init() {
        currentEnemies = new List<Enemy>();
        SpawnEnemy(playerRef.transform.position + new Vector3(4,0,0));
        SpawnEnemy(playerRef.transform.position + new Vector3(6, 0, 0));
        SpawnEnemy(playerRef.transform.position + new Vector3(8, 0, 0));
    }

    // Use this for initialization
    void Awake () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnEnemy(Vector3 spawnPos) {
        GameObject enemyObj = (GameObject)Instantiate(Resources.Load("Enemy"), spawnPos, Quaternion.identity);
        Enemy newEnemy = enemyObj.GetComponent<Enemy>();
        newEnemy.PlayerRef = playerRef;
        currentEnemies.Add(newEnemy);
    }
}
