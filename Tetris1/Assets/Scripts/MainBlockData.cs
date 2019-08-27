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

    void Awake()
    {
        GetNeightborsToList();
        GetMaterialForBlocks();
        SetMaterialToBlocks();
    }

    public void GetNeightborsToList()
    {
        myNeightbors = new List<IBlockProp>(GetComponentsInChildren<IBlockProp>());
    }

    public void GetMaterialForBlocks()
    {

    }

    public void SetMaterialToBlocks()
    {
        Material mat = GetComponent<MaterialsPicker>().GetRandomMaterial();

        foreach(var cube in myNeightbors)
        {
            cube.myRenderer.material = mat;
        }
    }

    public void AddToWall()
    {

    }

}
