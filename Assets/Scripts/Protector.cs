using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Protector helper tries to position itself in front of the player
public class Protector : Helper {
    
    [SerializeField]
    float speed = 4;
    float horizontalOffset;

    // Use this for initialization
    void Start () {
        horizontalOffset = playerRef.GetComponent<SpriteRenderer>().bounds.extents.x * 2f;
    }
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        Vector3 playerFront = playerRef.transform.position + new Vector3(horizontalOffset, 0, 0);
        transform.position = Vector3.MoveTowards(transform.position, playerFront, step);
    }
}
