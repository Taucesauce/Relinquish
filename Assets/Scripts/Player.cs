using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Player : MonoBehaviour {
    //Input vars
    Rewired.Player player;
    bool upPressed = false;
    bool downPressed = false;
    bool leftPressed = false;
    bool rightPressed = false;

    //Movement Vars
    [SerializeField]
    float playerSpeed;


	// Use this for initialization
	void Awake () {
        player = ReInput.players.GetPlayer(0);
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
        ProcessInput();
	}

    void GetInput() {
        upPressed = player.GetButton("MoveUp");
        downPressed = player.GetButton("MoveDown");
        leftPressed = player.GetButton("MoveLeft");
        rightPressed = player.GetButton("MoveRight");
    }

    void ProcessInput() {
        if (upPressed) {
            transform.position += (Vector3.up * playerSpeed * Time.deltaTime);
        }

        if(downPressed) {
            transform.position += (Vector3.down * playerSpeed * Time.deltaTime);
        }

        if(leftPressed) {
            transform.position += (Vector3.left * playerSpeed * Time.deltaTime);
        }

        if(rightPressed) {
            transform.position += (Vector3.right * playerSpeed * Time.deltaTime);
        }
    }

    public Transform GetNearestEnemy() {
        List<Enemy> enemies = EnemySpawner.instance.CurrentEnemies;

        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Enemy potentialTarget in enemies) {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr) {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
            }
        }

        return bestTarget;
    }
}
