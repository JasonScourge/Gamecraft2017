using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.GetComponent<Human> () != null ||
			collider.gameObject.GetComponent<LegoBlock>() != null) {
			collider.gameObject.SetActive (false);
		}
	}
}
