using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

    public int Health = 3;

    // Update is called once per frame
    void Update(){
        
        PlayerHealth.health = Health;
        Debug.Log(Health);
        
        if (Health <= 0)
        {
            Die();
        }

        if (gameObject.transform.position.y < -10){
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Debug.Log("Dead");
        }
    }

    //Upon "Death" the prototype file is loaded, effectively restarting the game.
    void Die(){
        SceneManager.LoadScene(0);
    }
}
