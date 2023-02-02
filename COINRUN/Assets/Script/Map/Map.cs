using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    float current = 1.0f;

    MapManager mapData;

    public float Current => current;

    public MapManager MapData => mapData;

    private void Awake()
    {
        mapData = new MapManager();
    }
}
