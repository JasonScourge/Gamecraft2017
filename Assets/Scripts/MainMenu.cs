using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public GameObject toContinue;
	public GameObject instructions;

	private bool text;
	/// Scenes Index
	/// 0 - MainMenu
	/// 1 - GameScene

	void Start(){
		text = true;
	}

	void Update () {
		if (text) {
			if (Input.anyKeyDown) {
				toContinue.SetActive (false);
				instructions.SetActive (true);
			}
			StartCoroutine ("startTime");
		} else {
			startGame ();
		}
	}

	public void exitGame(){
		Application.Quit ();
	}

	public void startGame(){
		SceneManager.LoadScene (1);
	}

	IEnumerator startTime(){
		yield return new WaitForSecondsRealtime (5.0f);
		text = false;
	}

}
