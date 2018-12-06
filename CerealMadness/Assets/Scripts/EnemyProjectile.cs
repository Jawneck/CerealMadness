﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    public float speed;

    public int damage = 1;
    private Transform player;
    private Vector2 target;
   // PlayerDeath pd = new PlayerDeath();

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y){
            player.SendMessage("TakeDamage", damage);
            DestroyProjectile();
        }
	}

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            DestroyProjectile();
        }
    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
