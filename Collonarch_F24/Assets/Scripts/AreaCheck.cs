using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCheck : MonoBehaviour
{
    private int blockCount = 0;
    //if i put this area check on the block itself it will detect when it enters area and leaves out of bounds


    private void Start()
    {
        gameObject.tag = "Active";
    }

    private void Update()
    {
        Debug.Log(blockCount);
        
        if (blockCount == 5)
        {
            Debug.Log("gg you did it");
        }
        else
        {
            Debug.Log("ya fucked up");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if active block enters "build area", increment 1
        if (collision.gameObject.CompareTag("Build"))
        {
            blockCount++;
        }
        
        //if inactive block enters "out of bounds", turn it on
        if (collision.gameObject.CompareTag("No Build"))
        {
            gameObject.tag = "Active";
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //if active block leaves "out of bounds", turn it off
        if (collision.gameObject.CompareTag("No Build"))
        {
            gameObject.tag = "Inactive";
        }
        
        //if inactive block leaves "build area", increment -1
        if (collision.gameObject.CompareTag("Build"))
        {
            blockCount--;
        }
    }
}
