using UnityEngine;
using System.Collections;

public class Cannon_Script : MonoBehaviour {

	private float cooldown = 5;


	public GameObject leftBullet;
	public GameObject rightBullet;
	public GameObject player;
	public Transform spawnposition;

	private bool directionLeft;
	private Doozer_Controller script;

	// Use this for initialization
	void Start () {
		directionLeft = true;
		script = player.GetComponent<Doozer_Controller> ();
	}
	
	// Update is called once per frame
	void Update () {

		FlipCannon ();
		Shoot ();


	}

	public void DamageDone(int damage){


		Destroy (gameObject);
	}


	//Shoots a bullet every 200 Update.
	//Should be fixed into a IEnumerator
	private void Shoot(){


		if (cooldown == 0 && !script.dead) {


			if (player.transform.position.x < transform.position.x) {
				Instantiate (leftBullet, spawnposition.position, spawnposition.rotation);
			} else {
				Instantiate (rightBullet, spawnposition.position, spawnposition.rotation);
			}

			cooldown = 200;
		}

		cooldown--;

	}


	//Flip the cannon depending of where the player is
	private void FlipCannon(){


		if (!directionLeft && (player.transform.position.x < transform.position.x) || directionLeft && (player.transform.position.x > transform.position.x)) {
			directionLeft = !directionLeft;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}

	}

}
