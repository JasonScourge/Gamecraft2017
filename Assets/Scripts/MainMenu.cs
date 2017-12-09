using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public GameObject howToPlay;
	public GameObject creditsScreen;

	/// Scenes Index
	/// 0 - MainMenu
	/// 1 - GameScene

	void Update () {
		if (Input.anyKeyDown) {
			startGame ();
		}
	}

	public void exitGame(){
		Application.Quit ();
	}

	public void startGame(){
		SceneManager.LoadScene (1);
	}

	public void openInstructions(){
		howToPlay.SetActive (true);
	}

	public void closeInstructions(){
		howToPlay.SetActive (false);
	}

	public void openCredits(){
		creditsScreen.SetActive (true);
	}

	public void closeCredits(){
		creditsScreen.SetActive (false);
	}
}
