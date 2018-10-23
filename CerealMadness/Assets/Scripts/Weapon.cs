using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float offset;

    public GameObject projectile;
    public Transform shootingPoint;

    public float timeBetweenShots;
    public float startTimeBetweenShots;

    private void Update(){
        //Calculating the direction between the weapon and the mouse cursor
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //Calculating the amount of degrees the weapon must rotate to face the cursor
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //Setting the weapon rotation
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + offset);

        if(timeBetweenShots <= 0){
            //Spawning projectile at the tip of the weapon
            if (Input.GetMouseButtonDown(0)){
                Instantiate(projectile, shootingPoint.position, transform.rotation);
                //Resetting time between shots
                timeBetweenShots = startTimeBetweenShots;
            }
        }
        else{
            timeBetweenShots -= Time.deltaTime;
        }


    }
}
