using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour {

	private int index;

	// Use this for initialization
	void Start () {

		 index = SceneManager.GetActiveScene ().buildIndex; 
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	private void OnTriggerEnter2D (Collider2D collider){

		if (collider.CompareTag ("Player")) {
			StartCoroutine ("Fading");
		}
	}

	//Fade out the scene and load the next scene
	private IEnumerator Fading(){

		float fadeTime = GameObject.Find ("GameController").GetComponent<FadingScript> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (index + 1);

	}
}
