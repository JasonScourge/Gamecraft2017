using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoFoot : MonoBehaviour {

	public Blackboard blackboard;		// for tracking penalties if dinosaur steps on human

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.layer.Equals (LayerMask.NameToLayer ("Human"))) {
			collider.gameObject.GetComponent<Human> ().OnSquishedByFoot ();
			blackboard.DeductOneLife ();
		} else if (collider.gameObject.layer.Equals (LayerMask.NameToLayer ("Lego"))) {
			collider.gameObject.GetComponent<LegoBlock> ().OnSquishedByFoot ();
		}
	}
}
