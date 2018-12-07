using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

    public void Level1()
    {   //Loading the next scene in the build.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Level2()
    {   //Loading the next scene in the build.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Level3()
    {   //Loading the next scene in the build.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void Level4()
    {   //Loading the next scene in the build.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
}
