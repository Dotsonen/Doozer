using UnityEngine;
using System.Collections;

public class Level1Script : MonoBehaviour {

	public GameObject leftKeyImage;
	public GameObject rightKeyImage;
	public GameObject upKey;
	public GameObject player;

	private Transform playerTransform;
	private Transform leftKeyTransform;
	private Transform rightKeyTransform;
	private Transform upKeyTransform;

	// Use this for initialization
	void Start () {

		leftKeyImage.SetActive (false);
		rightKeyImage.SetActive (false);
		upKey.SetActive (false);

		leftKeyTransform = leftKeyImage.transform;
		rightKeyTransform = rightKeyImage.transform;
		upKeyTransform = upKey.transform;

	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown (KeyCode.R)){


				Application.LoadLevel("Level1");
		
		}



	
	}

	private void FixedUpdate(){

		playerTransform = player.transform;

		leftKeyTransform.position = new Vector2 (playerTransform.position.x - 10, playerTransform.position.y);
		rightKeyTransform.position = new Vector2 (playerTransform.position.x + 10, playerTransform.position.y);
		upKeyTransform.position = new Vector2 (playerTransform.position.x, playerTransform.position.y + 7);

		EnableHelpImages ();


	}


	public void EnableHelpImages(){


		if (player.transform.position.x < 0) {
			leftKeyImage.SetActive (true);
			rightKeyImage.SetActive (true);
		}else{
				leftKeyImage.SetActive (false);
				rightKeyImage.SetActive (false);
			}


		if (40 < player.transform.position.x && player.transform.position.x < 73) {
			upKey.SetActive (true);
		} else {
			upKey.SetActive (false);
		}


	}



}
