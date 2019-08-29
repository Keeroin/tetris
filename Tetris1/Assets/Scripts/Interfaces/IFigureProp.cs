using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFigureProp : IBlockProp
{ 
    Material figureMaterial { get; }

    List<IBlockProp> myNeightbors { get; }

    void GetNeightborsToList();
    void GetMaterialForBlocks();
    void SetMaterialToBlocks();
}

