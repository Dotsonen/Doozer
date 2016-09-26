using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	private int health = 40;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (health < 0) {

			Destroy (gameObject);

		}

	}


	public void DamageDone(int damage){

		Debug.Log ("Damage " + damage); 

		health -= damage;

	}
}
