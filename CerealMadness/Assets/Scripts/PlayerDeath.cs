using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

    public int Health;
 //   public PlayerHealth playerHealth;

    // Update is called once per frame
    void Update(){

 //       PlayerHealth.health = Health;

        if (gameObject.transform.position.y < -10){
            Die();
        }
    }

 /*   void onTriggerEnter2D()
    {
        if (Health <= 0){
            Die();
        }
    }*/

    //Upon "Death" the prototype file is loaded, effectively restarting the game.
    void Die(){
        SceneManager.LoadScene(0);
    }
}
