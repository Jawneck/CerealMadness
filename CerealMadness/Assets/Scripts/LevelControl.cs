using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelControl : MonoBehaviour {

    public int levelIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {   //Checking if player has entered the end level area trigger
        if (other.CompareTag("Player"))
        {   //Loading the next scene in the build.
            SceneManager.LoadScene(levelIndex);
        }
    }
}
