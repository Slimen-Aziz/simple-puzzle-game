using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuScript 
{
	[MenuItem("Tools/Assign Tile Material")]
	public static void AssignTileMat () {
		GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
		Material mat = Resources.Load<Material>("Tile");

		foreach (GameObject T in tiles)
			T.GetComponent<Renderer>().material = mat;
	}

	[MenuItem("Tools/Assign Cube Material")]
	public static void AssignCubeMat () {
		GameObject[] cubes = GameObject.FindGameObjectsWithTag("mvCube");
		Material mat = Resources.Load<Material>("mvCube");

		foreach (GameObject C in cubes)
			C.GetComponent<Renderer>().material = mat;
	}

	[MenuItem("Tools/Assign Cube Script")]
	public static void AssignCubeSc () {
		GameObject[] cubes = GameObject.FindGameObjectsWithTag("mvCube");

		foreach (GameObject C in cubes)
			C.AddComponent<Cube>();
	}
}
