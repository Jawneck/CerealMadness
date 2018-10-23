using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;

	private void Update () {
        //Moving the projectile forward
        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}
}
