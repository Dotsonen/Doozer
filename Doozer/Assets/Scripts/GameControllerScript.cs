using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


//Handles the score and restart face of the game 
public class GameControllerScript : MonoBehaviour {

	public int score;
	private int levelStartScore;
	private GUIText scoreText;
	private GameObject scoreObject;
	private FadingScript fadeScript;
	private GameObject restartObject;
	private GUIText restartText;

	private int index;


	private bool playerIsDead;
	private bool flash;
	// Use this for initialization
	void Start () {
		scoreObject = GameObject.Find ("ScoreObject");
		scoreText = scoreObject.GetComponent<GUIText> ();
	
		Object.DontDestroyOnLoad(gameObject);

		fadeScript = GetComponent<FadingScript> ();

		restartObject = GameObject.Find ("RestartObject");
		restartText = restartObject.GetComponent<GUIText> ();

		playerIsDead = false;
		flash = false;

		score = 0;
		PrintScore ();

	}
	
	// Update is called once per frame
	void Update () {

		//Show no score at end scene
		if (SceneManager.GetActiveScene ().buildIndex == 4) {
			scoreText.text = "";
		}

		if(Input.GetKeyDown (KeyCode.R)){

			//Restart the game if the game is finished
			if (SceneManager.GetActiveScene ().buildIndex == 4) {
				SetScore (0);
				SceneManager.LoadScene (0);

			} else if (SceneManager.GetActiveScene ().buildIndex == 0) {
				Destroy (gameObject);
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
			else  {
				//Restart the level
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
				SetScore (levelStartScore);
				restartText.text = "";
				playerIsDead = false;
				flash = false;

				StartCoroutine ("PrintAfterWait");
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}


		if (fadeScript.alpha == 1) {
			StartCoroutine ("Fading");
		}

	
		if (playerIsDead && !flash) {
			StartCoroutine ("RestartFlash");
		}
	
	}

	public void addScore (int points){

		score += points;
		PrintScore ();
	}

	public void PrintScore(){
		scoreText.text = ("Score: " + score);
	}

	public int GetScore(){
		return score;
	}

	public void SetScore(int newScore){
		score = newScore;
	}

	IEnumerator PrintAfterWait(){
		yield return new WaitForSeconds (0.1f);
		PrintScore ();
	}

	private IEnumerator Fading(){
		
		levelStartScore = score;
		yield return new WaitForSeconds (0.3f);
		fadeScript.BeginFade (-1);


	}

	public void SetDeath(){
		playerIsDead = true;

	}

	private IEnumerator RestartFlash(){

		flash = true;


		while (playerIsDead) {
			restartText.text = "Press 'R' for Restart";
			yield return new WaitForSeconds (0.5f);
			restartText.text = "";
			yield return new WaitForSeconds (0.5f);

		}

	}
		
}
