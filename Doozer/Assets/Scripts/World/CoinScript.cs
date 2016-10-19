using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

	private GameObject gameController;
	private GameControllerScript gcs;


	// Use this for initialization
	void Start () {

		gameController = GameObject.Find ("GameController");
		gcs = gameController.GetComponent<GameControllerScript> ();

	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (0, 4, 0);
	
	}

	private void OnTriggerEnter2D(Collider2D collider){

		if(collider.CompareTag("Player")){
			Destroy (gameObject);
			gcs.addScore (10);
		}

	}
}
