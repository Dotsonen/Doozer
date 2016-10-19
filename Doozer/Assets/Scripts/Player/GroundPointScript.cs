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

		script.myAnimator.SetTrigger ("Grounded");	

			script.isGrounded = true;
			script.doubleJump = true;

		if (collision.gameObject.tag == "HorizontalElevator") {
			myGameObject.transform.SetParent (collision.gameObject.transform);
		}

		if (collision.gameObject.tag != "HorizontalElevator") {
			myGameObject.transform.SetParent (null);
		}

		if (collision.gameObject.tag == "Elevator") {
			myGameObject.transform.SetParent (collision.gameObject.transform);
		}

		if (collision.gameObject.tag == "Enemy_Bullet") {
			script.deathHandling ();
		}



	}



	private void OnCollisionExit2D (Collision2D collision){
		script.isGrounded = false;

/*		if (collision.gameObject.tag == "Elevator") {
			myGameObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
		}
*/
	}

	private void OnCollisionStay2D (Collision2D collision){
		script.isGrounded = true;
	}




}
