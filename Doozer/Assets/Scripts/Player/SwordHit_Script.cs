using UnityEngine;
using System.Collections;

public class SwordHit_Script : MonoBehaviour {


	int damage = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	private void OnTriggerEnter2D(Collider2D collider){

		if(!collider.isTrigger && collider.CompareTag("Enemy")){

			collider.SendMessageUpwards ("DamageDone", damage);
		}

	}

}
