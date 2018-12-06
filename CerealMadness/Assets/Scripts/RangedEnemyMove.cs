using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyMove : MonoBehaviour {


    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    private int health = 2;
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject projectile;
    public Transform target;

    private ParticleSystem particleSystem;

    void Awake(){
        particleSystem = GetComponent<ParticleSystem>();

        timeBetweenShots = startTimeBetweenShots;
    }


    void Start () {
        //The target is the object which has the tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        //Checking how far the the enemy is from the player, with the enemy moving towards the player if it has not reached stopping distance
		if(Vector2.Distance(transform.position, target.position) > stoppingDistance){
            //Moving the enemy from its position towards the targets postion at its given speed, *Time.deltaTime stops faster movement on faster performance computers  
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //Checking to see if enemy is near enough to stop moving towards target, and is not too near to begin with
        }else if(Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance){
              //Stopping enemy from moving
              transform.position = this.transform.position;
        }else if (Vector2.Distance(transform.position, target.position) < retreatDistance){
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);

        }

        if(timeBetweenShots <= 0){
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        } else{
            timeBetweenShots -= Time.deltaTime;  
        }

        //Destroying enemy when health reaches 0
        if (health <= 0){
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage){
        health -= damage;
        //Starts particle system when enemy takes damage
        particleSystem.Play();
    }
}

