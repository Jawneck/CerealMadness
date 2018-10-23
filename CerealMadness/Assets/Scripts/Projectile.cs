using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float distance;
    public LayerMask whatIsSolid;

    private void Update () {

        //Detecting if projectile hits enemy
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsSolid);
        if(hit.collider != null){
            if (hit.collider.CompareTag("Enemy")){
                Debug.Log("Enemy hit");
            }
        }

        //Moving the projectile forward
        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}
}
