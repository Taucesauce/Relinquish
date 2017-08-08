using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : Helper {
    
    [SerializeField]
    float speed = 4;

    // Use this for initialization
    void Start() {
        helperRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 enemyToAttack = playerRef.GetNearestEnemy().position;
        helperRB.velocity = new Vector2(enemyToAttack.x - transform.position.x, enemyToAttack.y - transform.position.y).normalized * speed;
    }
}
