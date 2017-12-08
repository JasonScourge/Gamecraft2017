﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public LayerMask targets;

	GameObject draggedObject;		// for tracking the target object to be dragged
	
	// Update is called once per frame
	void Update () {
		// Captures mouse inputs and handle them
		if (Input.GetMouseButtonDown (0)) {
			OnMouseClick (Input.mousePosition);
		} else if (Input.GetMouseButtonUp (0)) {
			OnMouseRelease ();
		} else if (Input.GetMouseButton (0)) {
			OnMouseDrag ();
		}
	}

	void OnMouseClick (Vector3 mousePosition) {
		// Raycast to detect any interactable objects being hit
		RaycastHit2D hitRes = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (mousePosition), Vector2.zero, Mathf.Infinity, targets);

		// Register a target object, if any
		draggedObject = (hitRes.collider == null) ? null : hitRes.collider.gameObject;

		if (draggedObject != null) {
			// Set the interactable's callback function
			draggedObject.GetComponent<Interactables> ().OnMouseClick (OnDraggedObjectDestroy);
		}
	}

	void OnMouseRelease () {
		if (draggedObject != null) {
			// Release the object
			draggedObject.GetComponent<Interactables> ().OnMouseRelease ();
			draggedObject = null;
		}
	}

	void OnMouseDrag () {
		if (draggedObject != null) {
			draggedObject.GetComponent<Interactables> ().FollowMouse (Input.mousePosition);
		}
	}

	// Callback to remove object reference when interactable object is being destroyed
	void OnDraggedObjectDestroy () {
		draggedObject = null;
	}
}
