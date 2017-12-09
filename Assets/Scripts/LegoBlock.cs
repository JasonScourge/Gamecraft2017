using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoBlock : Interactables {

	AudioSource audioSource;
	public AudioClip legoBreakClip;

	void Start () {
		audioSource = GameObject.Find ("InteractableAudiosource").GetComponent<AudioSource> ();
	}

	public override void OnSquishedByFoot () {
<<<<<<< HEAD
        //Camera.main.GetComponent<CameraMovement> ().TriggerSlowEffect (slowAmount, slowDuration);
        Camera.main.GetComponent<CameraMovement>().IncreaseSpeed(-0.075f);
=======
		audioSource.PlayOneShot (legoBreakClip);
        Camera.main.GetComponent<CameraMovement>().IncreaseSpeed(-0.05f);
>>>>>>> 79654dfce352ebd7c392e2fec8056f025c4f34e4
        base.OnSquishedByFoot ();
	}
}
