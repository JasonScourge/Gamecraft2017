using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoFoot : MonoBehaviour {

	public Blackboard blackboard;		// for tracking penalties if dinosaur steps on human

	AudioSource audioSource;
	public AudioClip dinoKillRoarClip;
	public AudioClip dinoPainRoarClip;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.layer.Equals (LayerMask.NameToLayer ("Human"))) {
			collider.gameObject.GetComponent<Human> ().OnSquishedByFoot ();
			blackboard.DeductOneLife ();
			audioSource.PlayOneShot (dinoKillRoarClip);
		} else if (collider.gameObject.layer.Equals (LayerMask.NameToLayer ("Lego"))) {
			collider.gameObject.GetComponent<LegoBlock> ().OnSquishedByFoot ();
			audioSource.PlayOneShot (dinoPainRoarClip);
		}
	}
}
