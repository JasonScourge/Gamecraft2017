using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard : MonoBehaviour {

	public GameOverTransition endGameScript;

    public GameObject[] heartUIArray;

	public int startingLives;
	int lives;

	public int Lives {
		get {
			return lives;
		}
	}

	public void DeductOneLife () {
		lives -= 1;
        heartUIArray[lives].SetActive(false);
    }

	// Use this for initialization
	void Start () {
		lives = startingLives;
	}
	
	// Update is called once per frame
	void Update () {
		if (lives <= 0) {
			endGameScript.gameOver ();
		}
	}
}
