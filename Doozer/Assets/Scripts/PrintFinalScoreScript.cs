using UnityEngine;
using System.Collections;

public class PrintFinalScoreScript : MonoBehaviour {

	private GameObject gameController;
	private GameControllerScript gcs;

	private int finalScore, score;
	private GUIText scoreText;


	// Use this for initialization
	void Start () {

		gameController = GameObject.Find ("GameController");
		gcs = gameController.GetComponent<GameControllerScript> ();

		scoreText = GetComponent<GUIText> ();

		finalScore = gcs.GetScore ();
		score = 0;

		StartCoroutine ("PrintScore");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	private IEnumerator PrintScore(){
		while (score <= finalScore) {
			scoreText.text = (score.ToString());
			yield return new WaitForSeconds (0.1f);
			score += 10;

		}
	}
}
