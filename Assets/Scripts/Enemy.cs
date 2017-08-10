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

    private void OnTriggerEnter2D(Collider2D collision) {
        string objectCollided = collision.gameObject.name;

        switch (objectCollided) {
            case "Player":
                Debug.Log("Player Hit");
                break;
            case "Attacker(Clone)":
            case "Protector(Clone)":
                Debug.Log(objectCollided + " Hit");
                EventManager.TriggerIntEvent("Helper Hit", collision.gameObject.GetComponent<Helper>().ID);
                Destroy(gameObject);
                break;
            case "Bullet(Clone)":
                Debug.Log("Bullet Hit");
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
        }
    }
}
