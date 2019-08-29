using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockProp
{
    Transform myTransform { get; }
    MeshRenderer myRenderer { get; }
}
