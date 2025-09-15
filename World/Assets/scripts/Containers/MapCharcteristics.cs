using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCharcteristics 
{
     public float scale;
     public int octaves;
     public float persistence;
     public float lacunarity;
     public int seed;

     public MapCharcteristics(int _seed, float _scale, int _octaves, float _persistence, float _lacunarity)
    {
        scale = _scale;
        octaves = _octaves;
        persistence = _persistence;
        lacunarity = _lacunarity;
        seed = _seed;
    }
}
