using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MaterialsSO", menuName = "MaterialsSO", order = 51)]
public class MaterialsSO : ScriptableObject
{
    public List<Material> Materials;
}
