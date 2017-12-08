using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Just in case if we modify the game speed to increase difficulty
		Time.timeScale = 1.0f;
	}
	
	public void exitGame(){
		Application.Quit ();
	}

	public void backToMainMenu(){
		SceneManager.LoadScene (0);
	}

	public void playAgain(){
		SceneManager.LoadScene (1);
	}
}
