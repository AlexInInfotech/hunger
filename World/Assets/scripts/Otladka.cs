using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Otladka 
{
    public static void PrintMainMapToConsol(TileType[] type)
    {
        string str = "";
        for (int i = 0; i < MapManager.TileMapWidth + 2; i++)
        {
            for (int j = 0; j < MapManager.TileMapWidth + 2; j++)
                switch (type[j + i * (MapManager.TileMapWidth + 2)])
                {
                    case TileType.earth:
                        str += "e";
                        break;
                    case TileType.water:
                        str += "w";
                        break;
                    case TileType.sand:
                        str += "s";
                        break;
                    default:
                        str += "L";
                        break;
                }
            Debug.Log(" i =  " + i + "   " + str);
            str = "";
        }
    }
}
