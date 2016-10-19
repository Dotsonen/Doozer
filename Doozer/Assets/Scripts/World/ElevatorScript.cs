using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour {


	private float  upLimit, liveYPos;
	private bool directionUp;
	private Rigidbody2D myRigidbody;
	public Transform playerTransform;

	// Use this for initialization
	void Start () {

		directionUp = true;
		upLimit = 9.5f;


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

			if(gameObject.GetComponentInChildren<Rigidbody2D>() != null)
				BroadcastMessage ("Release", null, SendMessageOptions.DontRequireReceiver);

			Destroy (gameObject);

		
		}

	}


}
