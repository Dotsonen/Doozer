using UnityEngine;
using System.Collections;


//Makes the Camera follow the player
public class CameraScript : MonoBehaviour {

	public GameObject player;
	private Transform transform;
	private Transform transformPlayer;
	private int limit = 20;

	// Use this for initialization
	void Start () {

		transform = GetComponent<Transform> ();

		transformPlayer = player.GetComponent<Transform> ();



	}

	// Update is called once per frame
	void Update () {

		transform = GetComponent<Transform> ();

		transformPlayer = player.GetComponent<Transform> ();

		if(needCameraMovingRight())
		transform.position = new Vector3 (transformPlayer.position.x - limit, transform.position.y, transform.position.z);

		if(needCameraMovingLeft())
			transform.position = new Vector3 (transformPlayer.position.x + limit, transform.position.y, transform.position.z);


	
	}


	private bool needCameraMovingRight(){

		if (Mathf.Abs (transformPlayer.position.x - transform.position.x) > limit) {
			if(transform.position.x < transformPlayer.position.x)
			return true;
		}

		return false;
	}

	private bool needCameraMovingLeft(){

		if (Mathf.Abs (transformPlayer.position.x - transform.position.x) > limit) {
			if(transform.position.x > transformPlayer.position.x)
				return true;
		}

		return false;
	}

}
