using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsPicker : MonoBehaviour
{
    [SerializeField]
    private MaterialsSO source;
    private List<Material> materials;

    public Material GetRandomMaterial()
    {
        materials = source.Materials;
        return materials[Random.Range(0, materials.Count)];
    }
}
