﻿using UnityEngine;
using System.Collections;

public class TriggerTest : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D other){


		other.transform.parent = gameObject.transform;

	}

	private void OnTriggerExit2D (Collider2D other){


		other.transform.parent = null;
	}
}
