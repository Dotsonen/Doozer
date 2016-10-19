using UnityEngine;
using System.Collections;

public class HiddenSignScript : MonoBehaviour {

	public GameObject parent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter2D (Collider2D collider){

		if(collider.CompareTag("Player")){
			gameObject.SetActive(false);
			parent.SetActive (true);
		}
	}
}
