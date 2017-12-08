using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	CameraMovement cameraMovementScript;

	public float speedIncrement;
	public int speedIncrementInterval;
	float accumulatedDuration;

	bool hasIncrementedSpeed = true;	// this is set to true to prevent speed increment on game start!

	void Start () {
		cameraMovementScript = Camera.main.gameObject.GetComponent<CameraMovement> ();
	}

	void Update () {
		accumulatedDuration += Time.deltaTime;

		if (Mathf.FloorToInt (accumulatedDuration) % speedIncrementInterval == 0) {
			if (!hasIncrementedSpeed) {
				// Increment the speed of the dinosaur after every set interval
				hasIncrementedSpeed = true;
				cameraMovementScript.IncreaseSpeed (speedIncrement);
			}
		} else if (Mathf.FloorToInt (accumulatedDuration) % speedIncrementInterval == 1) {
			hasIncrementedSpeed = false;
		}
	}
}
