using UnityEngine;
using System.Collections;

public class GroundPointScript : MonoBehaviour {

	public GameObject myGameObject;
	private Doozer_Controller script;

	// Use this for initialization
	void Start () {

		script = myGameObject.GetComponent<Doozer_Controller> ();

	}
	
	// Update is called once per frame
	void Update () {



	}

	private void OnCollisionEnter2D (Collision2D collision){
			script.isGrounded = true;
			script.doubleJump = true;

	}



	private void OnCollisionExit2D (Collision2D collision){
			script.isGrounded = false;

		
	}	

	private void OnCollisionStay2D (Collision2D collision){


		script.isGrounded = true;
	}


}
