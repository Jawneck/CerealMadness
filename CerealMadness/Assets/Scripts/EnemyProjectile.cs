using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    //Constants and Variables
    public float speed;
    public int damage = 1;
    private Transform player;
    private Vector2 target;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        //Moving projectile
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //Dealing damage to the player on impact
        if (transform.position.x == target.x && transform.position.y == target.y){
            player.SendMessage("TakeDamage", damage);
            DestroyProjectile();
        }
	}

    //When projectile collides with player, projectile is destroyed
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            DestroyProjectile();
        }
    }

    //Method which destroys the projectile
    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
