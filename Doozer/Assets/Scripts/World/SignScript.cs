using UnityEngine;
using System.Collections;

public class SignScript : MonoBehaviour {

	private int lapCounter;
	private bool rotate;

	// Use this for initialization
	void Start () {

		rotate = true;

		StartCoroutine ("stopRotate");

	}
	
	// Update is called once per frame
	void Update () {

		if(rotate)
		transform.Rotate (0, 10, 0);

		if (!rotate && Mathf.Abs (transform.rotation.y) > 5) {
				transform.Rotate (0, 1, 0);
		} else if(!rotate) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
	
		
	}

	IEnumerator stopRotate(){

		yield return new WaitForSeconds (2);
		rotate = false;

	}


		
}
