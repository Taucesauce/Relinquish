using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base class for various helpers in-game.
//A helper is a pickup the player gets to assist with defeating enemies.
public class Helper : MonoBehaviour {
    protected Player playerRef;
    public Player PlayerRef { get { return playerRef; } set { playerRef = value; } }
    protected Rigidbody2D helperRB;
    private int id;
    public int ID { get { return id; } set { id = value; } }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void HitEvent() {

    }
}
