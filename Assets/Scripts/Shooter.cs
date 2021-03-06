﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shooter Helper fires at enemies close to the player.
public class Shooter : Helper {
    [SerializeField]
    float speed = 4;
    float horizontalOffset;
    float verticalOffset;

    // Use this for initialization
    void Start() {
        horizontalOffset = playerRef.GetComponent<SpriteRenderer>().bounds.extents.x * -2f;
        verticalOffset = playerRef.GetComponent<SpriteRenderer>().bounds.extents.y * 2f;
        helperRB = GetComponent<Rigidbody2D>();
        FireProjectile();
    }

    // Update is called once per frame
    void Update () {
        float step = speed * Time.deltaTime;
        Vector3 playerFront = playerRef.transform.position + new Vector3(horizontalOffset, verticalOffset, 0);
        transform.position = Vector3.MoveTowards(transform.position, playerFront, step);
        helperRB.velocity = new Vector2(playerFront.x - transform.position.x, playerFront.y - transform.position.y).normalized * speed;
    }

    void FireProjectile() {
        GameObject newBullet = (GameObject)Instantiate(Resources.Load("Bullet"), transform.position, Quaternion.identity);
    }
}
