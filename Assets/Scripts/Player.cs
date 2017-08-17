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
    Rigidbody2D playerRigidBody;

	// Use this for initialization
	void Awake () {
        player = ReInput.players.GetPlayer(0);
        playerRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        playerSpeed = 5 - (.5f * HelperManager.helperCount);
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
        if (!player.GetAnyButton()) { playerRigidBody.velocity = Vector2.zero; }
        Vector2 totalVelocity = new Vector2();

        if (upPressed) {
            totalVelocity += (Vector2.up * playerSpeed);
        }

        else if(downPressed) {
            totalVelocity += (Vector2.down * playerSpeed);
        }

        if(leftPressed) {
            totalVelocity += (Vector2.left * playerSpeed);
        }

        else if(rightPressed) {
            totalVelocity += (Vector2.right * playerSpeed);
        }

        playerRigidBody.velocity = totalVelocity;
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
