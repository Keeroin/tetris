using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFigureProp : IBlockProp, IInputGetter
{
    RotationLook rotationLook { get; }
    Material figureMaterial { get; }

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
