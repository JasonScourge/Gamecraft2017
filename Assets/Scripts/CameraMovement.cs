using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float cameraSpeed = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //transform.position -= (Vector3.right * cameraSpeed);
	}

    public void MoveCamera() {
        transform.position -= new Vector3(0, 0, 4);
    }
}
