using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour {
	public GameObject[] countdown;

    public GameObject pausedText;

	private float timePaused;
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
            TogglePause();
        }
	}

    public void TogglePause() {
        if (isPaused) {
            resumeGame();
        } else {
            pauseGame();
        }
    }

	public void pauseGame(){
		if (!stopPause) {
			Time.timeScale = timePaused;
            pausedText.SetActive(true);
            isPaused = true;
		}
	}

	public void resumeGame(){
		if (!stopPause) {
			stopPause = !stopPause;
            pausedText.SetActive(false);
            StartCoroutine("resumeTiming");
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
		Time.timeScale = 1.0f;

		yield return new WaitForSecondsRealtime (0.1f);
		isPaused = false;
		stopPause = !stopPause;
	}

}
