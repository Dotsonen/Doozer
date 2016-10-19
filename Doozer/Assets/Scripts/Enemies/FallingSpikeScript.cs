using UnityEngine;
using System.Collections;

public class FallingSpikeScript : MonoBehaviour {

	int layerMask = 1 << 8;           //The layer with only the player character 
	// Use this for initialization


	void FixedUpdate(){
		//Checks if a player is underneath, start using gravity in case
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down, Mathf.Infinity, layerMask);
		if (hit.collider != null) {
			GetComponent<Rigidbody2D> ().isKinematic = false;
		}

	}

	//Destroy this gameobject with any contact
	private void OnCollisionEnter2D(Collision2D collision){

		Destroy (gameObject);
	}
}
