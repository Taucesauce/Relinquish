using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    SpriteRenderer sr;
    Random rand;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        sr.color = new Color(Random.value, Random.value, Random.value);
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "Player") {
            EventManager.TriggerEvent("Pickup Hit");
            Destroy(gameObject);
        }
    }
}
