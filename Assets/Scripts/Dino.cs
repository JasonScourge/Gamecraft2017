using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour {

    CameraMovement MainCameraScript;

    public float animationSpeed = 1f;

    public Animator animator;

	// Use this for initialization
	void Start () {
        MainCameraScript = Camera.main.GetComponent<CameraMovement>();
        animator = GetComponent<Animator>();
    }

    public void MoveMainCamera() {
        MainCameraScript.MoveCamera();
    } 
}
