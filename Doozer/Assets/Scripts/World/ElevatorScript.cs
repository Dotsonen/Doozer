using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour {


	private float startYPos, upLimit, downLimit, liveYPos;
	private bool directionUp;
	private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {

		directionUp = true;
		startYPos = transform.position.y;

		upLimit = startYPos + 10;
		downLimit = startYPos - 10;

		myRigidbody = GetComponent<Rigidbody2D> (); 
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){

		liveYPos = transform.position.y;

		MoveGround (liveYPos);

	}


	private void MoveGround(float ypos){

		if (directionUp && ypos < upLimit) {
			myRigidbody.position = new Vector2 (transform.position.x, ypos + 0.2f);
		} else if (directionUp && !(ypos < upLimit)) {
			directionUp = !directionUp;
		}

		if (!directionUp && ypos > downLimit) {
			myRigidbody.position = new Vector2(transform.position.x, (ypos - 0.2f));

			//	myRigidbody.velocity = new Vector2 (-4, 0);
		} else if (!directionUp && !(ypos > downLimit)) {
			directionUp = !directionUp;
		}


	}
}
