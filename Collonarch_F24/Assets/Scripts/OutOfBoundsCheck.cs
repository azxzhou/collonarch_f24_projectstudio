using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsCheck : MonoBehaviour
{
    public bool outOfBounds = true;
    public int blockCount = 0;
    public static OutOfBoundsCheck instance { get; private set; }
    private void Update()
    {
        Debug.Log(blockCount);
    }
    
    private void OnCollisionExit(Collision collision) 
    {
        //if uncounted block leaves out of bounds, change it to counted
        if (collision.gameObject.CompareTag("Counted Block"))
        {
            blockCount++;
        }
        
        //if the last of the uncounted blocks leaves out of bounds, consider the thing valid
        if (collision.gameObject.CompareTag("Counted Block") && blockCount == 5) 
        {
            outOfBounds = false;
        }
        else
        {
            outOfBounds = true;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        //if counted block enters out of bounds, uncount it and mark as uncounted
        if (collision.gameObject.CompareTag("Counted Block"))
        {
            collision.gameObject.tag = "Blocks";
            blockCount--;
        }
    }
    
}