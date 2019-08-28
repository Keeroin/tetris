using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MaterialsPicker))]
public class MainBlockData : MonoBehaviour, IFigureProp
{
    [SerializeField]
    private MeshRenderer MRenderer;
    public MeshRenderer myRenderer
    {
        get { return MRenderer; }
        set { MRenderer = value; }
    }

    public Transform myTransform { get; private set; }
    public Material figureMaterial { get; private set; }
    public RotationLook rotationLook { get; private set; }

    public List<IBlockProp> myNeightbors { get; private set; }

    private InputManager inputManager;
    private float moveSpeed = 10f;
    private float step = 0;
    private bool previousStepWasRight = true;


    void Awake()
    {
        myTransform = gameObject.transform;
        inputManager = gameObject.GetComponent<InputManager>();

        GetNeightborsToList();
        GetMaterialForBlocks();
        SetMaterialToBlocks();
    }

    void Update()
    {
        GetInputValuesAndMove();
    }

    public void GetNeightborsToList()
    {
        myNeightbors = new List<IBlockProp>(GetComponentsInChildren<IBlockProp>());
    }

    public void GetMaterialForBlocks()
    {
        figureMaterial = GetComponent<MaterialsPicker>().GetRandomMaterial();
    }

    public void SetMaterialToBlocks()
    {
        foreach(var cube in myNeightbors)
        {
            cube.myRenderer.material = figureMaterial;
        }
    }

    public void GetInputValuesAndMove()
    {

        if (inputManager.HorizontalValue > 0f && !previousStepWasRight)
        {
            step = 0f;
            previousStepWasRight = false;
        }
        step += inputManager.HorizontalValue * moveSpeed * Time.fixedDeltaTime;
        if (-1f > step || step > 1f )
        {
            if (Mathf.Abs(myTransform.position.x + step) > 13) return; //невихід за граничні точки
            myTransform.position += Vector3.right * step;
            step = 0f;
        }
    }

    public void AddToWall()
    {

    }

}
