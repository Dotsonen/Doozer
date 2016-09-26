using UnityEngine;
using System.Collections;

public class BoundaryScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerExit2D (Collider2D collider){

		if (collider.CompareTag("Enemy_Bullet")) {

			Destroy (collider.gameObject);
		}

	}
}
