using UnityEngine.Tilemaps;

public class GroundData
{
    public Tilemap tilemap;
    public TileBase tile;

    public Tilemap TransitionTilemap;
    public TileBase TransitionTile;
    public GroundData() { }
    public GroundData(TileBase _tile, Tilemap _tilemap)
    {
        tile = _tile;
        tilemap = _tilemap;
    }
    public GroundData(TileBase _tile, Tilemap _tilemap, TileBase _TransitionTile, Tilemap _TransitionTilemap)
    {
        tile = _tile;
        tilemap = _tilemap;
        TransitionTilemap = _TransitionTilemap;
        TransitionTile = _TransitionTile;
    }

}