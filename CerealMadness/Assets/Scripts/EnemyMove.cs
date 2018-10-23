using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    private float enemySpeed = 2;
    private float stoppingDistance = 0.5f;
    private int health = 5;

    private ParticleSystem particleSystem;

    void Awake(){
        particleSystem = GetComponent<ParticleSystem>();
    }

    //Variable to hold the game object that the enemy is chasing after ie "Player"
    private Transform target;

	// Use this for initialization
	void Start (){
        //The target is the object which has the tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update (){
        //Checking the distance between the enemy and its target, allowing enemy to follow until stoppingDistance
		if(Vector2.Distance(transform.position, target.position) > stoppingDistance){

            //Moving the enemy from its position towards the targets postion at its given speed
            transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
        }

        //Destroying enemy when health reaches 0
        if(health <= 0){
            Destroy(gameObject);
        }
	}

    public void TakeDamage(int damage){
        health -= damage;
        //Starts particle system when enemy takes damage
        particleSystem.Play();
    }
}
