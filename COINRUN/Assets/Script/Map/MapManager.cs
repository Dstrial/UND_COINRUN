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
        public string coin;         // 0이면 없음, 1이면 1층, 2면 2층, 3이면 3층........
    }

    public MapManager()
    {
        map = new mapData();
        map.f4   = "";
        map.f3   = "000000000000000000000011000000110000000000000000";
        map.f2   = "000000000000000000001100000011000000000000000000";
        map.f1   = "111111111111111111100000111000001111111111111111";
        map.coin = "000000000000011111122333211223332111111111111111";
    }
}
