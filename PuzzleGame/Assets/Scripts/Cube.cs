using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

public Vector3 newPos;
public Material StopMat;
public Material DefMat;
public bool blocked = false;

	void Awake () {
		newPos = transform.position;
	}
	
	void Update () {
		transform.position = Vector3.Lerp(transform.position, newPos, 3 * Time.deltaTime);
	}

	void OnMouseDown () {
		if (!blocked) {
			GetComponent<Renderer>().material = StopMat;
			blocked = true;
		}
		else {
			GetComponent<Renderer>().material = DefMat;
			blocked = false;
		}
	}
}
