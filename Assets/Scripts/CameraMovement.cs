using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    Vector3 newPosition;
    Vector3 initPosition;
    private Vector3 currentVelocity;
    private bool isMoving = false;

    public AnimationClip dinoClip;
    public Animator animator;

    private bool increaseSpeedNextAnimCycle = false;
    private float increaseSpeedValue;

    // Update is called once per frame
    void FixedUpdate () {
        if (isMoving) {
            this.transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref currentVelocity, (dinoClip.length/10) / animator.speed, float.MaxValue, Time.deltaTime);
        }

        if(transform.position == newPosition) {
            isMoving = false;
            if (increaseSpeedNextAnimCycle) {
                animator.speed += increaseSpeedValue;
            }
        }
    }

    public void MoveCamera() {
        initPosition = transform.position;
        newPosition = initPosition - new Vector3(12, 0, 0);
        isMoving = true;
    }

    public void IncreaseSpeed(float increaseSpeedValue) {
        this.increaseSpeedValue = increaseSpeedValue;
        increaseSpeedNextAnimCycle = true;
    }
}
