using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigControl : MonoBehaviour {

public bool inside;
	void OnTriggerEnter (Collider col) {
		inside = true;
	}

	void OnTriggerExit () {
		inside = false;
	}
}
