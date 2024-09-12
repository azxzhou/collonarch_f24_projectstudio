using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Vector3 mousePositionOffset;
    Vector3 newGridPos;

    int gridSize = 5;
    private Vector3 GetMouseWorldPosition()
    {
        //get mouse position and return worldpoint
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
        newGridPos = transform.position;
    }
    private void OnMouseUp()
    {
        //make object snap to grid when released
        transform.position = new Vector3(
            RoundToNearestGrid(newGridPos.x),
            transform.position.y,
            RoundToNearestGrid(newGridPos.z));
    }

    private void OnMouseOver() //check if mouse is over object
    {
        //rotate on right click
        if (Input.GetMouseButtonDown(1))
        {
            transform.Rotate(0,90,0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    float RoundToNearestGrid(float pos)
    {
        //rounding bullshit
        float xDiff = pos % gridSize;
        bool isPositive = pos > 0 ? true : false;
        pos -= xDiff;
        if (Mathf.Abs(xDiff) > (gridSize/2))
        {
            if (isPositive)
            {
                pos += gridSize;
            }
            else
            {
                pos -= gridSize;
            }
        }
        return pos;
    }
}
