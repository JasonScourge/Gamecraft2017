using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour {
	public GameObject[] countdown;

	private float timePaused;
	private float storedTime;
	private bool isPaused;
	private bool stopPause;

	// Use this for initialization
	void Start () {
		isPaused = false;
		stopPause = false;
		timePaused = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {
			if (isPaused) {
				resumeGame();
			} else {
				pauseGame();
			}
		}
	}

	public void pauseGame(){
		if (!stopPause) {
			storedTime = Time.timeScale;
			Time.timeScale = timePaused;
			isPaused = true;
		}
	}

	public void resumeGame(){
		if (!stopPause) {
			stopPause = !stopPause;
			StartCoroutine ("resumeTiming");
		}
	}

	IEnumerator resumeTiming(){
		for (int i = 0; i < countdown.Length; i++) {
			if (i == 0) {
				countdown [i].SetActive (true);
			} else {
				countdown [i-1].SetActive (false);
				countdown [i].SetActive (true);
			}
			yield return new WaitForSecondsRealtime (0.9f);
		}
		countdown [countdown.Length-1].SetActive(false);
		Time.timeScale = storedTime;

		yield return new WaitForSecondsRealtime (0.1f);
		isPaused = false;
		stopPause = !stopPause;
	}

}
