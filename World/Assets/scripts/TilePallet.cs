using UnityEngine.Tilemaps;


public static class TilePallet
{
    //    public static TileBase[] Waterr;
    //    public static Tilemap WaterTilemap;
    public static GroundBase Water = new GroundBase();
    public static GroundBase Sand = new GroundBase();
    public static GroundBase Earth = new GroundBase();
    public static GroundBase TransitWater = new GroundBase();
    public static GroundBase TransitSand = new GroundBase();
    public static GroundBase TransitEarth = new GroundBase();

}
public class GroundBase
{
    public Tilemap tilemap;
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
            case TileForm.Hall_LeftBottom:
                return Hall_LeftBottom[index];
            case TileForm.Hall_LeftTop:
                return Hall_LeftTop[index];
            case TileForm.Hall_RightBottom:
                return Hall_RightBottom[index];
            case TileForm.Hall_RightTop:
                return Hall_RightTop[index];
            case TileForm.Wall_Bottom:
                return Wall_Bottom[index];
            case TileForm.Wall_Left:
                return Wall_Left[index];
            case TileForm.Wall_Right:
                return Wall_Right[index];
            case TileForm.Wall_Top:
                return Wall_Top[index];
            default:
                return null;
        }
    }
    public TileBase GetTile(TileForm tileform, BiomType biom, TileForm biomform)
    {
        byte index = (byte)biom;
        if (tileform == TileForm.Fill)
            tileform = biomform;
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

