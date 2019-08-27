using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFigureProp : IBlockProp
{
    RotationLook rotationLook { get; }

    List<IBlockProp> myNeightbors { get; }

    void GetNeightborsToList();
    void GetMaterialForBlocks();
    void SetMaterialToBlocks();
    void AddToWall();
}

public enum RotationLook
{
    forward,
    right,
    backwards,
    left
}
