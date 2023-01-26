using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager
{
    public mapData map;

    public struct mapData
    {
        public string f1;
        public string f2;
        public string f3;
        public string f4;
    }

    public MapManager()
    {
        map = new mapData();
        map.f1 = "111111111111111111100011111000111111111111111111";
        map.f2 = "";
        map.f3 = "";
        map.f4 = "";
    }
}
