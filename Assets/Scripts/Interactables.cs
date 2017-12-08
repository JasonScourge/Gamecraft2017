using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour {

	// Checks if player is currently dragging the target interactable.
	protected bool isDragged;	// initialized to false

	public bool IsDragged {
		get {
			return isDragged;
		}
	}

	// Callback functions for when object is stepped on by dinosaur
	public delegate void OnDestroyCallback ();
	protected OnDestroyCallback onDestroyCallbackFunc;

	public virtual void OnMouseClick (OnDestroyCallback destroyCallbackFunc) {
		isDragged = true;
		onDestroyCallbackFunc = destroyCallbackFunc;
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	public virtual void OnMouseRelease () {
		// TODO: 1. Do raycast to find the destination cell
		// TODO: 2. Snap this object to a cell (if permissible)
		isDragged = false;
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
	}

	// Called by the dinosaur's foot.
	public virtual void OnSquishedByFoot () {
		isDragged = false;
		onDestroyCallbackFunc ();
		Destroy (this.gameObject);
	}

	public virtual void FollowMouse (Vector3 mousePosition) {
		if (isDragged) {
			// Makes this object follow the mouse.
			gameObject.GetComponent<Rigidbody2D>().MovePosition(Camera.main.ScreenToWorldPoint(mousePosition));
		}
	}
}
