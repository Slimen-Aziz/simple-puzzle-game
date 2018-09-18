using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

public GameObject cubes;

public bool isRow;
public int RC;
public int type;

	void OnMouseDown () {
		cubes.GetComponent<GameController>().Move(RC, type, isRow);
	}
	
}
