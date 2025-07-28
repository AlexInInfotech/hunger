using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinMap
{
    public float[] floatArray;
    public int width;
    public int size;
    public PerlinMap() { }
    public PerlinMap(int _width, int _size)
    {
        width = _width;
        size = _size;
    }
}
