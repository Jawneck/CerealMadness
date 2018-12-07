using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkBottleMove : MonoBehaviour
{
    //Constants and Variables
    public float enemySpeed = 2;
    public float stoppingDistance = 0.5f;
    private int health = 5;
    public int damage;
    public float lastAttackTime;
    public float attackDelay;
    private ParticleSystem particleSystem;

    void Awake(){
        particleSystem = GetComponent<ParticleSystem>();
    }

    //Variable to hold the game object that the enemy is chasing after ie "Player"
    private Transform target;

    // Use this for initialization
    void Start(){
        //The target is the object which has the tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update(){
        //Checking the distance between the enemy and its target, allowing enemy to follow until stoppingDistance
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance){

            //Moving the enemy from its position towards the targets postion at its given speed
            transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
        }

        //Destroying enemy when health reaches 0
        if (health <= 0){
            Destroy(gameObject);
        }

        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        //Dealing damage to the player when in range
        if (distanceToPlayer < stoppingDistance)
        {//Giving a delay to the attack time to stop attack being continuous
            if (Time.time > lastAttackTime + attackDelay){
                target.SendMessage("TakeDamage", damage);
                lastAttackTime = Time.time;
            }

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //Starts particle system when enemy takes damage
        particleSystem.Play();
    }
}
