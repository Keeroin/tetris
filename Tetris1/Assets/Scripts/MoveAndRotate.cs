using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotator : MonoBehaviour, IInputGetter
{
    public Transform blockTransform { get; private set; }
    public bool isCanBeControled { get; private set; }
    
    private InputManager inputManager;
    private float moveSpeed = 10f;
    private float step = 0;
    private bool previousStepWasRight = true;


    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        blockTransform = gameObject.transform;
        
    }

    private void Update()
    {
        MoveWithInputValues();
        RotateWithInputValues();
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

    public void DisableContorls(GameObject disabler)
    {
        //if (disabler is ...)
        inputManager.enabled = false;
    }
}