
using UnityEngine.Tilemaps;
using UnityEngine;
using System;


public static class TilePallet
{
    public static int CountBioms;
    public static GroundBase Water = new GroundBase();
    public static GroundBase Sand = new GroundBase();
    public static GroundBase Earth = new GroundBase();
}
public class GroundBase
{
    public Tilemap tilemap;
    public int CountStates;
    public TileBase[] Filled;
    public TileBase[] Wall_Right;
    public TileBase[] Wall_Left;
    public TileBase[] Wall_Top;
    public TileBase[] Wall_Bottom;
    public TileBase[] Corner_RightBottom;
    public TileBase[] Corner_RightTop;
    public TileBase[] Corner_LeftBottom;
    public TileBase[] Corner_LeftTop;
    public TileBase[] Hall_RightBottom;
    public TileBase[] Hall_RightTop;
    public TileBase[] Hall_LeftBottom;
    public TileBase[] Hall_LeftTop;
    public float GetGreenState(TileForm biomform, BiomType biomtype)
    {
        return (int)biomform * (int)biomtype / (float)CountStates;
    }
    public float GetRedState(BiomType biomtype)
    {
        return  (int)biomtype / (float)TilePallet.CountBioms;
    }
    public TileBase GetTile(TileForm tileform, BiomType biom)
    {
        byte index = (byte)biom;
        switch (tileform)
        {
            case TileForm.Fill:
                return Filled[index];
            case TileForm.Corner_LeftBottom:
                return Corner_LeftBottom[index];
            case TileForm.Corner_LeftTop:
                return Corner_LeftTop[index];
            case TileForm.Corner_RightBottom:
                return Corner_RightBottom[index];
            case TileForm.Corner_RightTop:
                return Corner_RightTop[index];
            case TileForm.Wall_Bottom:
                return Wall_Bottom[index];
            case TileForm.Wall_Left:
                return Wall_Left[index];
            case TileForm.Wall_Right:
                return Wall_Right[index];
            case TileForm.Wall_Top:
                return Wall_Top[index];
       /*     case TileForm.Rit_LeftBottom:
                return Rit_LeftBottom[index];
            case TileForm.Rit_LeftTop:
                return Rit_LeftTop[index];
            case TileForm.Rit_RightBottom:
                return Rit_RightBottom[index];
            case TileForm.Rit_RightTop:
                return Rit_RightTop[index];*/
            default:
                return null;
        }
    }
}

