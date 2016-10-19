using UnityEngine;
using System.Collections;

public class Doozer_Controller : MonoBehaviour {

	private int movementSpeed = 25;
	private int jumpPower = 20;
	private float movementForce = 200f;
	private Rigidbody2D doozer_rigidBody;
	public Animator myAnimator;

	private float horizontal;
	private float jump;

	private bool isAttacking; 

	private bool directionRight;   
	public bool isGrounded;
	private bool jumping;
	public bool doubleJump;

	private int counter = 0;

	public bool dead;

	public Collider2D attackBox;

	private GameObject gameController;
	private GameControllerScript gcs;



	// Use this for initialization
	void Start () {

		directionRight = true;
		dead = false;
		isGrounded = false;
		isAttacking = false;
		jumping = false;
		doubleJump = true;

		attackBox.enabled = false;
	
		doozer_rigidBody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();

		gameController = GameObject.Find ("GameController");
		gcs = gameController.GetComponent<GameControllerScript> ();


	}
	
	// Update is called once per frame
	void Update () {

		HandleInputs ();
	}

	void FixedUpdate(){

		if (!dead) {
			

			horizontal = Input.GetAxis ("Horizontal");

			FlipCharacter (horizontal);
			HandlePhysics ();
			HandleJump ();
			HandleAttack ();
			HandleMovement (horizontal);


		}


	}


	//Add force to the player untill maxSpeed is reached
	private void HandleMovement(float horizontal){


		if ((Mathf.Abs (doozer_rigidBody.velocity.x) < movementSpeed)) {
			doozer_rigidBody.AddForce (new Vector2 (horizontal * movementForce, 0)); 
		} else  {

			doozer_rigidBody.velocity = new Vector2 (horizontal * movementSpeed, doozer_rigidBody.velocity.y);

		}
			myAnimator.SetFloat ("speed", Mathf.Abs (horizontal));


		if (doozer_rigidBody.position.y < -33) {
			deathHandling ();
		}
	}

	//Add jumpforce to the player when requested if jumping is available
	private void HandleJump(){

		if ((jumping && isGrounded) || (jumping && doozer_rigidBody.isKinematic)) {
			myAnimator.SetTrigger ("jump"); 
			doozer_rigidBody.velocity = new Vector2 (doozer_rigidBody.velocity.x, jumpPower);
			jumping = false;
		}

		if (jumping && !isGrounded && doubleJump) {
			myAnimator.SetTrigger ("jump"); 
			doozer_rigidBody.velocity = new Vector2 (doozer_rigidBody.velocity.x, jumpPower);
			doubleJump = false;

		}

		jumping = false;
	}

	//Set the attackbox enabled when player is requsting an attack
	private void HandleAttack(){


		if (isAttacking && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")){
			myAnimator.SetTrigger ("attack");
			attackBox.enabled = true;
			counter = 42;  								//Attackbox is enabled for 42 fixedUpdates
		}

		if (counter == 0)
			attackBox.enabled = false;

		isAttacking = false;
		counter--;

	}

	//Flips the player when it starts moving in the opposite direction as current
	private void FlipCharacter(float horizontal){

		if (horizontal < 0 && directionRight || horizontal > 0 && !directionRight) {

			doozer_rigidBody.velocity = new Vector2(0, doozer_rigidBody.velocity.y);

			directionRight = !directionRight;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;

		}

	}


	//Set booleans for different input of the player.
	//These booleans are used in respectively handling.
	private void HandleInputs(){
		if (Input.GetButtonDown ("Attack")) {
			isAttacking = true;
		}
		if(Input.GetButtonDown("Jump")){
			jumping = true;
		}
	}

	//Checks if player collide with an enemy, start deathHandling if so.
	private void OnCollisionEnter2D(Collision2D collision){

		if (collision.gameObject.tag == "Enemy_Bullet") {
			deathHandling ();
		}


	}

	// Set the character to follow physics and unfollow physics when needed
	private void HandlePhysics(){

		if (!doozer_rigidBody.isKinematic) {
			if (Mathf.Abs (horizontal) < 0.1 && isGrounded && doozer_rigidBody.velocity.y < 0.1) {
				doozer_rigidBody.isKinematic = true;
			} 
		}
		if (doozer_rigidBody.isKinematic) {
			if (Mathf.Abs (horizontal) > 0.1 || doozer_rigidBody.velocity.y > 0.1) {
				doozer_rigidBody.isKinematic = false;
			}
		}
	}

	//Release the character from a temporary parent 
	private void Release(){

		transform.SetParent (null);
		doozer_rigidBody.isKinematic = false;
		isGrounded = false;
	}


	//Set the enviroment incase of a death of the player
	public void deathHandling(){

		if (!dead) {
			if (doozer_rigidBody.isKinematic) {
				doozer_rigidBody.isKinematic = false;
			}

			myAnimator.SetTrigger ("death");
			dead = true;
			gcs.SetDeath ();
		}
		doozer_rigidBody.velocity = new Vector2(0, doozer_rigidBody.velocity.y);
	}
}
