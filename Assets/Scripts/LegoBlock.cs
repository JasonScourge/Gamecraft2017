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
        //Camera.main.GetComponent<CameraMovement> ().TriggerSlowEffect (slowAmount, slowDuration);
        Camera.main.GetComponent<CameraMovement>().IncreaseSpeed(-0.075f);
		audioSource.PlayOneShot (legoBreakClip);
        base.OnSquishedByFoot ();
	}
}
