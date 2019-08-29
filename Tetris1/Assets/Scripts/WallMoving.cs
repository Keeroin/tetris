using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoving : MonoBehaviour
{
    public Transform wallTransform { get; private set; }
    private float stepTimer = 0f;
    private readonly float stepLimit = 1.5f;
    private readonly float step = 1f;

    private void Awake()
    {
        wallTransform = gameObject.transform;
    }

    private void Update()
    {
        MoveWall();
    }

    void MoveWall()
    {
        stepTimer += Time.deltaTime;
        if (stepTimer > stepLimit)
        {
            stepTimer = 0f;
            wallTransform.localPosition += Vector3.back * step;
        }
    }
}
