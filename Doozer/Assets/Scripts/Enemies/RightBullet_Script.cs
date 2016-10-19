using UnityEngine;
using System.Collections;

public class RightBullet_Script : MonoBehaviour {

	private float bullet_speed = 20;

	private Rigidbody2D rigidbody;


	// Use this for initialization
	void Start () {

		rigidbody = GetComponent<Rigidbody2D> ();

		rigidbody.velocity = new Vector2 (bullet_speed, 0);  // Instantiate the bullet with a fixed speed

	}

	// Update is called once per frame
	void Update () {

	}


	private void OnCollisionEnter2D (Collision2D collision){


		Destroy (gameObject);
	}
}
