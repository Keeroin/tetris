using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFigureProp : IBlockRenderer
{ 
    Material figureMaterial { get; }

    List<IBlockRenderer> myNeightbors { get; }

    void GetNeightborsToList();
    void GetMaterialForBlocks();
    void SetMaterialToBlocks();
    void AddToWall();
}

