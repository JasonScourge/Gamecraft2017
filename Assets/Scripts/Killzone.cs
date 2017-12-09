using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour {

    public CameraMovement cameraMoveScript;

	void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.GetComponent<Human>() != null) {
            cameraMoveScript.IncreaseSpeed(0.1f);
            collider.gameObject.SetActive(false);
        }

        if (collider.gameObject.GetComponent<LegoBlock>() != null) {
			collider.gameObject.SetActive (false);
		}
	}
}
