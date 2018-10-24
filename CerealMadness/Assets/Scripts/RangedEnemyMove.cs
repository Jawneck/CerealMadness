using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyMove : MonoBehaviour {


    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public Transform target;


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
        }
    }
}
