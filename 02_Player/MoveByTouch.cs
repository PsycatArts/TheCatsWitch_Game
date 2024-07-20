﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);      //store current touch pos as world coordinate
            Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
        }
        /*
        //move obj to touch position
        if (Input.touchCount > 0)       //if there is ANY touch input
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position); //store position of touch as world coordinate
            touchPosition.z = 0f;
            transform.position = touchPosition;
        }*/
    }
}
