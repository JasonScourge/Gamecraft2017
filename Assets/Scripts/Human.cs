using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Interactables {

	public AudioClip squishedClip;
	AudioSource audioSource;

	void Start () {
		audioSource = GameObject.Find ("InteractableAudiosource").GetComponent<AudioSource> ();
	}

	public override void OnSquishedByFoot () {
		audioSource.PlayOneShot (squishedClip);
		base.OnSquishedByFoot ();
	}
}
