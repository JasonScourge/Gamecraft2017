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

        if (transform.position == newPosition) {
            isMoving = false;
        }
    }

    public void MoveCamera() {
        initPosition = transform.position;
        newPosition = initPosition - new Vector3(12, 0, 0);
        isMoving = true;
    }

    public void IncreaseSpeed(float increaseSpeedValue) {
        animator.speed += increaseSpeedValue;
        Debug.Log(animator.speed);
    }

    public void TriggerSlowEffect (float slowAmount, float delayDuration) {
		StartCoroutine (SlowDinosaurCoroutine (slowAmount, delayDuration));
	}

	// Distributes the slow effect over 3 intervals
	IEnumerator SlowDinosaurCoroutine(float slowAmount, float delayDuration) {
		float oldSpeed = animator.speed;
		float oldSpeedIncreaseValue = this.increaseSpeedValue;

		// Perform slowing effect
		float newSpeed = Mathf.Clamp(oldSpeed - slowAmount, 0, Mathf.Infinity);

		animator.speed = newSpeed;
		IncreaseSpeed (0);

		yield return new WaitForSeconds (delayDuration);
		animator.speed = oldSpeed;
		IncreaseSpeed (oldSpeedIncreaseValue);
	}
}
