using UnityEngine;
using System.Collections;

public class Doozer_Controller : MonoBehaviour {

	public int movementSpeed = 5;
	public int jumpPower = 5;
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


	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){

		if (!dead) {
			
		
			horizontal = Input.GetAxis ("Horizontal");

			FlipCharacter (horizontal);

			HandleInputs ();
			HandlePhysics ();
			HandleJump ();
			HandleAttack ();
			HandleMovement (horizontal);


		}


	}

	private void HandleMovement(float horizontal){

	//	if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag ("Attack")) {

			doozer_rigidBody.velocity = new Vector2 (horizontal * movementSpeed, doozer_rigidBody.velocity.y);
			myAnimator.SetFloat ("speed", Mathf.Abs (horizontal));


	//	}
	}

	private void HandleJump(){

		if ((jumping && isGrounded) || jumping && doozer_rigidBody.isKinematic) {
			myAnimator.SetTrigger ("jump"); 
			doozer_rigidBody.velocity = new Vector2 (doozer_rigidBody.velocity.x, jumpPower);
		}

		if (jumping && !isGrounded && doubleJump) {
			myAnimator.SetTrigger ("jump"); 
			doozer_rigidBody.velocity = new Vector2 (doozer_rigidBody.velocity.x, jumpPower);
			doubleJump = false;

		}

		jumping = false;
	}

	private void HandleAttack(){

		if (isAttacking) {
			doozer_rigidBody.velocity = new Vector2(0, doozer_rigidBody.velocity.y);
		}


		if (isAttacking && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")){
			myAnimator.SetTrigger ("attack");
			doozer_rigidBody.velocity = new Vector2(0, doozer_rigidBody.velocity.y);
			attackBox.enabled = true;
			counter = 42;
		}

		if (counter == 0)
			attackBox.enabled = false;

		isAttacking = false;
		counter--;

	}


	private void FlipCharacter(float horizontal){

		if (horizontal < 0 && directionRight || horizontal > 0 && !directionRight) {

			directionRight = !directionRight;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;

		}

	}


	private void HandleInputs(){
		if (Input.GetButtonDown ("Attack")) {
			isAttacking = true;
		}
		if(Input.GetButtonDown("Jump")){
			jumping = true;
		}
	}


	private void OnCollisionEnter2D(Collision2D collision){

		if (collision.gameObject.tag == "Enemy_Bullet") {


			if (!dead) {
				myAnimator.SetTrigger ("death");
				dead = true;
			}
			doozer_rigidBody.velocity = new Vector2(0, doozer_rigidBody.velocity.y);

		}


	}


	private void HandlePhysics(){

		if (!doozer_rigidBody.isKinematic) {
			if (Mathf.Abs (horizontal) < 0.1 && isGrounded && doozer_rigidBody.velocity.y < 0.1) {
				doozer_rigidBody.isKinematic = true;
			} 

		}

		if (doozer_rigidBody.isKinematic) {
			if (Mathf.Abs (horizontal) > 0.1 || jumping) {
				doozer_rigidBody.isKinematic = false;
			}
		}
	}
}
