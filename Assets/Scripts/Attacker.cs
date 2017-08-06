using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : Helper {
    
    [SerializeField]
    float speed = 4;

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        float step = speed * Time.deltaTime;
        Vector3 enemyToAttack = playerRef.GetNearestEnemy().position;
        transform.position = Vector3.MoveTowards(transform.position, enemyToAttack, step);
    }
}
