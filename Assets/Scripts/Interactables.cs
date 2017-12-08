using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour {

	public LayerMask cellMask;

	Collider2D leftBound;
	Collider2D rightBound;
	Collider2D topBound;
	Collider2D bottomBound;

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

	void Awake () {
		leftBound = GameObject.Find ("LeftBound").GetComponent<BoxCollider2D> ();
		rightBound = GameObject.Find ("RightBound").GetComponent<BoxCollider2D> ();
		topBound = GameObject.Find ("TopBound").GetComponent<BoxCollider2D> ();
		bottomBound = GameObject.Find ("BottomBound").GetComponent<BoxCollider2D> ();
	}

	void Update () {
		// Checks if the object ends up outside the camera somehow,
		// then makes the player stop dragging it if he was initially dragging it
		float maxX = (rightBound.bounds.center + rightBound.bounds.extents).x;
		if (gameObject.transform.position.x > maxX) {
			gameObject.SetActive (false);
			if (onDestroyCallbackFunc != null) {
				isDragged = false;
				onDestroyCallbackFunc ();
			}
		}
	}

	public virtual void OnMouseClick (OnDestroyCallback destroyCallbackFunc) {
		isDragged = true;
		onDestroyCallbackFunc = destroyCallbackFunc;
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	public virtual void OnMouseRelease (Vector3 mousePosition) {
		isDragged = false;

		// Raycast to detect the cell being hit
		RaycastHit2D hitRes = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (mousePosition), Vector2.zero, Mathf.Infinity, cellMask);

		if (hitRes.collider == null) {
			// If raycast using mouse cursor position doesn't register any cell,
			// we use the object's position to determine which cell it should be on.
			Collider2D cellOverlap = Physics2D.OverlapPoint(GetComponent<Rigidbody2D>().position, cellMask);
			gameObject.transform.position = cellOverlap.gameObject.transform.position;
		} else {
			// If there's a detected cell from raycast result, use that.
			gameObject.transform.position = hitRes.collider.gameObject.transform.position;
		}

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
			gameObject.GetComponent<Rigidbody2D>().MovePosition(ClampMoveToPosition(mousePosition));
		}
	}

	public virtual Vector3 ClampMoveToPosition(Vector3 mousePosition) {
		Vector3 pointInWorldSpace = Camera.main.ScreenToWorldPoint (mousePosition);

		float minX = (leftBound.bounds.center + leftBound.bounds.extents).x;
		float maxX = (rightBound.bounds.center - rightBound.bounds.extents).x;

		float minY = (bottomBound.bounds.center + bottomBound.bounds.extents).y;
		float maxY = (topBound.bounds.center - topBound.bounds.extents).y;

		float clampedX = Mathf.Clamp (pointInWorldSpace.x, minX, Mathf.Infinity);
		float clampedY = Mathf.Clamp (pointInWorldSpace.y, minY, maxY);

		pointInWorldSpace.x = clampedX;
		pointInWorldSpace.y = clampedY;

		return pointInWorldSpace;
	}
}
