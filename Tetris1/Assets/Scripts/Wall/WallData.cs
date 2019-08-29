using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WallData : MonoBehaviour
{
    public List<Transform> figureBlocks;
    public bool isHaveBlocks = false;

    private List<Transform> wallBlocks;

    private void Awake()
    {
        wallBlocks = new List<Transform>();
        figureBlocks = new List<Transform>();
    }

    private void Update()
    {
        if (isHaveBlocks)
        {
            AddBlocksToList();
            isHaveBlocks = false;
            figureBlocks.Clear();
        }
    }

    public void AddBlocksToList()
    {
        foreach(var block in figureBlocks)
        {
            Vector3 arrayPos = block.localPosition;
            int z = Convert.ToInt32(arrayPos.z);
            int x = Convert.ToInt32(arrayPos.x);
            block.parent = gameObject.transform.GetChild(0);
            block.GetComponent<Block>().enabled = false;
            wallBlocks.Insert(z * x, block);
        }
    }
}
