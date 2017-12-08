﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class TreeTiling : MonoBehaviour {

    //Offset checking position
    public int offsetX = 2;

    //Check if need to intsantiate
    public bool hasARightBuddy = false;
    public bool hasALeftBuddy = false;

    //Used if object not tileable
    public bool reverseScale = false;

    private float spriteWidth = 0f;     //element width
    private Camera cam;
    private Transform myTransform;

    public int spawnChance = 5;

    private void Awake() {
        cam = Camera.main;
        myTransform = transform;

    }


    // Use this for initialization
    void Start() {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x;
    }

    // Update is called once per frame
    void Update() {
        if (!hasALeftBuddy || !hasARightBuddy) {
            //Calculate the camera extend (half the width) of what camera can see in world coordinates 
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;
            //Calculate the x position where the camera can see the edge of the sprite
            float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;
            float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;

            //Check if we can see the edge of the element
            if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && !hasARightBuddy) {
                MakeNewBuddy(1);
                hasARightBuddy = true;
            } else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && !hasALeftBuddy) {
                MakeNewBuddy(-1);
                hasALeftBuddy = true;
            }
        }
        CheckToDestroy();
    }

    //Create a buddy on the side required
    void MakeNewBuddy(int rightOrLeft) {
        //Calculate new position for our new buddy
        Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
        Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;

        //If not tileable, reverse x size of object
        if (reverseScale) {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
        }

        newBuddy.parent = myTransform.parent;
        if (rightOrLeft > 0) {
            newBuddy.GetComponent<TreeTiling>().hasALeftBuddy = true;
        } else {
            newBuddy.GetComponent<TreeTiling>().hasARightBuddy = true;
        }

        int randomInt = Random.Range(0, spawnChance);

        if(randomInt == 0) {
            newBuddy.GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        }
    }

    void CheckToDestroy() {
        float distanceFromCamera = Vector3.Distance(cam.transform.position, transform.position);

        if (distanceFromCamera >= 200f) {
            Destroy(gameObject);
        }
    }
}
