using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IBlockProp
{
    [SerializeField]
    private MeshRenderer MRenderer;
    public MeshRenderer myRenderer
    {
        get { return MRenderer; }
        set { MRenderer = value; }
    }

    public Transform myTransform { get; set; }

    private void Awake()
    {
        myTransform = gameObject.transform;
    }
}
