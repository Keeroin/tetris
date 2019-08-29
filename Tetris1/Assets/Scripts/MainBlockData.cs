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
    public Transform myTransform { get; private set; }
    public WallData wallData { get; private set; }
    public bool isIGiveList { get; private set; }

    public List<IBlockProp> myNeightbors { get; private set; }
 

    void Awake()
    {
        myTransform = gameObject.transform;
        wallData = GameObject.FindGameObjectWithTag("Wall").GetComponentInChildren<WallData>();


        GetNeightborsToList();
        GetMaterialForBlocks();
        SetMaterialToBlocks();

    }

    private void Update()
    {
        if (GetComponent<InputManager>().enabled == false && !isIGiveList)
            GiveListOf_MAR_Blocks();
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

    public void GiveListOf_MAR_Blocks()
    {
        foreach (var obj in myNeightbors)
        {
            Transform trans = obj.myTransform;
            wallData.figureBlocks.Add(trans);
        }
        isIGiveList = true;
    }
}
