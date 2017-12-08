using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoBlock : Interactables {

	public float slowAmount;
	public float slowDuration;

	public override void OnSquishedByFoot () {
		Camera.main.GetComponent<CameraMovement> ().TriggerSlowEffect (slowAmount, slowDuration);
		base.OnSquishedByFoot ();
	}
}
