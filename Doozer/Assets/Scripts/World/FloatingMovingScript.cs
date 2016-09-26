using UnityEngine;
using System.Collections;

public class FloatingMovingScript : MonoBehaviour {


	private float startXPos, rightLimit, leftLimit, liveXPos;
	private bool directionRight;
	private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
	
		directionRight = true;
		startXPos = transform.position.x;

		rightLimit = startXPos + 10;
		leftLimit = startXPos - 10;

		myRigidbody = GetComponent<Rigidbody2D> (); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

		liveXPos = transform.position.x;

		MoveGround (liveXPos);

	}


	private void MoveGround(float xpos){

		if (directionRight && xpos < rightLimit) {
			myRigidbody.position = new Vector2 (xpos + 0.2f, myRigidbody.position.y);
		} else if (directionRight && !(xpos < rightLimit)) {
			directionRight = !directionRight;
		}

		if (!directionRight && xpos > leftLimit) {
			myRigidbody.position = new Vector2 ((xpos - 0.2f), myRigidbody.position.y);

		//	myRigidbody.velocity = new Vector2 (-4, 0);
		} else if (!directionRight && !(xpos > leftLimit)) {
			directionRight = !directionRight;
		}
			

	}
}
