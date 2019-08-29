using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IBlockRenderer
{
    [SerializeField]
    private MeshRenderer MRenderer;
    public MeshRenderer myRenderer
    {
        get { return MRenderer; }
        set { MRenderer = value; }
    }
}
