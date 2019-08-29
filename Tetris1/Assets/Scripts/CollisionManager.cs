using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionManager : MonoBehaviour
{
    private MainBlockData mainBlockData;
    private WallData wallData;
    private MoverAndRotator moveAndRotator;


    private void Awake()
    {
        if (GetComponent<MainBlockData>() != null)
        {
            mainBlockData = GetComponent<MainBlockData>();
            moveAndRotator = GetComponent<MoverAndRotator>();
            wallData = mainBlockData.wallData;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            Debug.Log("Colliding");
            if (moveAndRotator != null)
            {
                moveAndRotator.movingToWall = false;
                if (mainBlockData.isIGiveList)
                    wallData.isHaveBlocks = true;
            }
        }
       
    }
}
