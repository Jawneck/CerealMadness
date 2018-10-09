using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //Variables used to clamp the camera into position, so it doesnt move off to the side.
    public GameObject Player;
    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;

    //Use this for initialization
    void Start(){
        //Searches the game and finds any GameObject with the Player tag.
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    //LateUpdate is called once per frame, at the end of the Update cycle.
    void LateUpdate(){
        float x = Mathf.Clamp(Player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(Player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);//Not changing z axis because game is 2D.
    }
}
