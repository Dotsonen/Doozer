using UnityEngine;
using System.Collections;

public class ElevatorSpawn : MonoBehaviour {

	public GameObject elevator;

	// Use this for initialization
	void Start () {
	
		StartCoroutine ("spawnElevator");

	}
	
	// Update is called once per frame
	void Update () {

		spawnElevator ();
	
	}


	IEnumerator spawnElevator(){

		while (true) {

			yield return new WaitForSeconds (4);

			Instantiate (elevator, transform.position, transform.rotation);
		}
	}
}
