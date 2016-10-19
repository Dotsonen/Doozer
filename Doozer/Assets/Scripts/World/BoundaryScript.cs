using UnityEngine;
using System.Collections;

public class BoundaryScript : MonoBehaviour {



	//Destroys bullets when they reach the boundary
	private void OnTriggerExit2D (Collider2D collider){

		if (collider.CompareTag("Enemy_Bullet")) {

			Destroy (collider.gameObject);
		}

	}
}
