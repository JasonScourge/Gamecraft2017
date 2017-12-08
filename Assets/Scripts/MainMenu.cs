using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject howToPlay;

	public void exitGame(){
		Application.Quit ();
	}

	public void startGame(){
		SceneManager.LoadScene (1);
	}

	public void instructionsOpen(){
		howToPlay.SetActive (true);
	}

	public void instructionsClose(){
		howToPlay.SetActive (false);
	}
}
