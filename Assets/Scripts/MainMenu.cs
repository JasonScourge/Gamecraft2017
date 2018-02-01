using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public GameObject toContinue;
	public GameObject instructions;

	private int count;
	/// Scenes Index
	/// 0 - MainMenu
	/// 1 - GameScene

	void Start () {
		count = 0;
	}

	void Update () {
		if (Input.anyKeyDown) {
			if (count == 0) {
				toContinue.SetActive (false);
				instructions.SetActive (true);
				count = 1;
			} else if (count > 0) {
				StartCoroutine ("startTime");
			}
		}
	}

	public void exitGame () {
		Application.Quit ();
	}

	public void startGame () {
		SceneManager.LoadScene (1);
	}

	IEnumerator startTime () {
		yield return new WaitForSecondsRealtime (0.5f);
		startGame ();
	}

}