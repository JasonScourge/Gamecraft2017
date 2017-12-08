using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	public float startingMoveSpeed;
	float moveSpeed;

	public float MoveSpeed {
		get {
			return moveSpeed;
		}
		set {
			moveSpeed = value;
		}
	}

	void Start () {
		moveSpeed = startingMoveSpeed;
	}

	void Update () {
		// TODO: move the camera and gradually ramp up the camera's movement speed over time
	}
}
