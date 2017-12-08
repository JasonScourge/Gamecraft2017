using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard : MonoBehaviour {

	public GameOverTransition endGameScript;

	public int startingLives;
	int lives;

	public int Lives {
		get {
			return lives;
		}
	}

	public void DeductOneLife () {
		lives -= 1;
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
