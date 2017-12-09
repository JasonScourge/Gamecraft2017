using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Killzone : MonoBehaviour {

    public CameraMovement cameraMoveScript;
	public Text scoreText;
	int score = 0;

	void OnGUI () {
		scoreText.text = "Humans saved: " + score.ToString ();
	}


	void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.GetComponent<Human>() != null) {
            cameraMoveScript.IncreaseSpeed(0.05f);
            collider.gameObject.SetActive(false);
			score += 1;
        }

        if (collider.gameObject.GetComponent<LegoBlock>() != null) {
			collider.gameObject.SetActive (false);
		}
	}
}
