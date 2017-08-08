using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Player playerRef;
    public Player PlayerRef { get { return playerRef; } set { playerRef = value; } }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        string objectCollided = collision.gameObject.name;

        switch (objectCollided) {
            case "Player":
                Debug.Log("Player Hit");
                break;
            case "Attacker":
                Debug.Log("Attacker Hit");
                break;
            case "Protector":
                Debug.Log("Protector Hit");
                break;
            case "Shooter":
                Debug.Log("Shooter Hit");
                break;
        }
    }
}
