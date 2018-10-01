using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

public GameObject[] cubes;
public GameObject[,] mvcubes = new GameObject[5, 5];

public GameObject TR1, TR2;

public int score = 0;

public Text wintext;

void initCubes () {
	int s = 0;
	for (int i=0;i<5;i++) {
		for (int j=0;j<5;j++) {
			mvcubes[i,j] = cubes[s++];
			//Debug.Log(mvcubes[i,j]);
		}
	}
}

void RandomTrig () {
	do {
		TR1.transform.position = new Vector3(Random.Range(0, 4), TR1.transform.position.y, Random.Range(0, 4));
		TR2.transform.position = new Vector3(Random.Range(0, 4), TR1.transform.position.y, Random.Range(0, 4));
	} while (TR1.transform.position == TR2.transform.position) ;
}

void Awake () {
	initCubes();
	RandomTrig();
}

// pull row --> type= -1
// push row <-- type= 1
// move column up type= 1
//move column down type= -1
public void Move (int RC, int type, bool isRow) {

	int countdown= (type< 0) ? 4 : 0;
	int compare= (type< 0) ? 0 : 4;

	if (isRow) {
		if (type< 0) {
			for (int i=countdown;i> compare;i+= type) {mvRow(RC, i,type);}
		}
		else {
			for (int i= countdown;i< compare;i+= type) {mvRow(RC, i, type);}
		}
	}
	else {
		if (type< 0) {
			for (int i=countdown;i> compare;i+= type) {mvCol(RC, i,type);}
		}
		else {
			for (int i= countdown;i< compare;i+= type) {mvCol(RC, i, type);}
		}
	}

}

void mvRow (int row, int i, int type) {
	if (mvcubes[row, i] == null) {
			if (mvcubes[row, i+type] != null){
				if (!mvcubes[row, i+type].GetComponent<Cube>().blocked) {
				mvcubes[row, i+type].GetComponent<Cube>().newPos = new Vector3(mvcubes[row, i+type].GetComponent<Transform>().position.x, mvcubes[row, i+type].GetComponent<Transform>().position.y, Mathf.RoundToInt(mvcubes[row, i+type].GetComponent<Transform>().position.z + type));
				mvcubes[row, i] = mvcubes[row, i+type];
				mvcubes[row, i+type] = null;
				}
			}
		}
}

void mvCol (int col, int i, int type) {
	if (mvcubes[i, col] == null) {
			if (mvcubes[i+type, col] != null){
				if (!mvcubes[i+type, col].GetComponent<Cube>().blocked) {
				mvcubes[i+type, col].GetComponent<Cube>().newPos = new Vector3(Mathf.RoundToInt(mvcubes[i+type, col].GetComponent<Transform>().position.x + type), mvcubes[i+type, col].GetComponent<Transform>().position.y, mvcubes[i+type, col].GetComponent<Transform>().position.z);
				mvcubes[i, col] = mvcubes[i+type, col];
				mvcubes[i+type, col] = null;
				}
			}
		}
}

void Update () {
        if (checkEmpty(TR1) && checkEmpty(TR2)) {
            score += 1;
            RandomTrig();
            wintext.text = "Score : " + score;
        }
}

    bool checkEmpty (GameObject trig)
    {

        int posR = Mathf.RoundToInt(4 - trig.GetComponent<Transform>().position.x);
        int posC = Mathf.RoundToInt(4 - trig.GetComponent<Transform>().position.z);

        if ((trig.GetComponent<TrigControl>().inside == false) && mvcubes[posR, posC] == null)
        {
            return true;
        }

        return false;
    }

}
