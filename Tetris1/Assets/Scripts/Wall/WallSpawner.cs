using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> figuresPrefabs;

    private WallData wallData;
    private WallMoving wallMoving;

    private void Awake()
    {
        wallData = GetComponent<WallData>();
        wallMoving = GetComponent<WallMoving>();


    }

    void SpawnBlocks()
    {

    }

}
