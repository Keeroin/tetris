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
    
    public Material figureMaterial { get; private set; }

    public List<IBlockRenderer> myNeightbors { get; private set; }


    void Awake()
    {
        GetNeightborsToList();
        GetMaterialForBlocks();
        SetMaterialToBlocks();
    }

    //void Update()
    //{
       
    //}

    public void GetNeightborsToList()
    {
        myNeightbors = new List<IBlockRenderer>(GetComponentsInChildren<IBlockRenderer>());
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

    public void AddToWall()
    {

    }

}
