using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAndRotator : MonoBehaviour, IInputGetter
{
    public Transform blockTransform { get; private set; }
    public bool isCanBeControled { get; private set; }

    public bool movingToWall = false;
    
    private InputManager inputManager;
    private float moveSpeed = 10f;
    private float step = 0;
    private bool previousStepWasRight = true;
    private Vector3 movingSpeed = new Vector3(0f, 0f, 1f);

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        blockTransform = gameObject.transform;
    }

    private void Update()
    {
        MoveWithInputValues();
        RotateWithInputValues();

        if (inputManager.SpaceButtonPressed)
            ShootFigureInWall();

        if (movingToWall) 
            blockTransform.position += movingSpeed;
    }


    public void MoveWithInputValues()
    {

        if (inputManager.HorizontalValue > 0f && !previousStepWasRight)
        {
            step = 0f;
            previousStepWasRight = false;
        }

        step += inputManager.HorizontalValue * moveSpeed * Time.fixedDeltaTime;

        if (-1f > step || step > 1f)
        {
            if (Mathf.Abs(blockTransform.position.x + step) > 13) return; //невихід за граничні точки
                blockTransform.position += Vector3.right * step;
            step = 0f;
        }
    }

    public void RotateWithInputValues()
    {
        if (inputManager.UpButtonPressed)
            blockTransform.Rotate(new Vector3(0, 90, 0), Space.Self);

        if (inputManager.DownButtonPressed)
            blockTransform.Rotate(new Vector3(0, -90, 0), Space.Self);
    }

    public void DisableControls()
    {
        inputManager.enabled = false;
    }

    public void ShootFigureInWall()
    {
        DisableControls();
        step = 0f;
        movingToWall = true;
    }
}