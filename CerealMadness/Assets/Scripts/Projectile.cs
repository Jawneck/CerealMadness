using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float distance;
    public int damage = 1;
    public LayerMask whatIsSolid;

    private void Update () {

        //Detecting if projectile hits enemy
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsSolid);
        if(hit.collider != null){
            if (hit.collider.CompareTag("RangedEnemy")){
                Debug.Log("Enemy hit");
                //Calling TakeDamage function upon collision
                hit.collider.GetComponent<RangedEnemyMove>().TakeDamage(damage);
                //Destroying projectile upon collision
                Destroy(gameObject);
            }else if (hit.collider.CompareTag("Enemy")){
                Debug.Log("Enemy hit");
                //Calling TakeDamage function upon collision
                hit.collider.GetComponent<EnemyMove>().TakeDamage(damage);
                //Destroying projectile upon collision
                Destroy(gameObject);
            }
        }

        //Moving the projectile forward
        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}
}
