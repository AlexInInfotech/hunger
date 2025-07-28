using UnityEngine;
using UnityEngine.Tilemaps;


public class TileManager : MonoBehaviour
{
    public Tilemap _WaterTilemap;
    public Tilemap _SandTilemap;
    public Tilemap _EarthTilemap;
    public Tilemap _WaterTransitTilemap;
    public Tilemap _SandTransitTilemap;
    public Tilemap _EarthTransitTilemap;
    static float RiverLow;
    static float RiverHight;
    static float BiomLow;
   // static float ColdLow;
    static float WaterHight;
    static float SandHight;
    static Tilemap WaterTilemap;
    static Tilemap SandTilemap;
    static Tilemap EarthTilemap;
    static Tilemap WaterTransitTilemap;
    static Tilemap SandTransitTilemap;
    static Tilemap EarthTransitTilemap;

    public float _RiverLow = 0.43f;
    public float _RiverHight = 0.54f;
    public float _BiomLow = 0.3f;
  //  public float _ColdLow = 0.7f;
    public float _WaterHight = 0.14f;
    public float _SandHight = 0.4f;

    public TileBase[] waterFill;


    public TileBase[] sandFill;
    public TileBase[] sandWall_Right;
    public TileBase[] sandWall_Top;
    public TileBase[] sandWall_Left;
    public TileBase[] sandWall_Bottom;
    public TileBase[] sandCorner_RightBottom;
    public TileBase[] sandCorner_RightTop;
    public TileBase[] sandCorner_LeftTop;
    public TileBase[] sandCorner_LeftBottom;

    public TileBase[] earthFill;
    public TileBase[] earthWall_Right;
    public TileBase[] earthWall_Top;
    public TileBase[] earthWall_Left;
    public TileBase[] earthWall_Bottom;
    public TileBase[] earthCorner_RightBottom;
    public TileBase[] earthCorner_RightTop;
    public TileBase[] earthCorner_LeftTop;
    public TileBase[] earthCorner_LeftBottom;

    public TileBase[] TransitwaterWall_Right;
    public TileBase[] TransitwaterWall_Top;
    public TileBase[] TransitwaterWall_Left;
    public TileBase[] TransitwaterWall_Bottom;
    public TileBase[] TransitwaterCorner_RightBottom;
    public TileBase[] TransitwaterCorner_RightTop;
    public TileBase[] TransitwaterCorner_LeftTop;
    public TileBase[] TransitwaterCorner_LeftBottom;
    public TileBase[] TransitwaterHall_RightBottom;
    public TileBase[] TransitwaterHall_RightTop;
    public TileBase[] TransitwaterHall_LeftTop;
    public TileBase[] TransitwaterHall_LeftBottom;


    public TileBase[] TransitsandWall_Right;
    public TileBase[] TransitsandWall_Top;
    public TileBase[] TransitsandWall_Left;
    public TileBase[] TransitsandWall_Bottom;
    public TileBase[] TransitsandCorner_RightBottom;
    public TileBase[] TransitsandCorner_RightTop;
    public TileBase[] TransitsandCorner_LeftTop;
    public TileBase[] TransitsandCorner_LeftBottom;
    public TileBase[] TransitsandHall_RightBottom;
    public TileBase[] TransitsandHall_RightTop;
    public TileBase[] TransitsandHall_LeftTop;
    public TileBase[] TransitsandHall_LeftBottom;
    
    public TileBase[] TransitearthFill;
    public TileBase[] TransitearthWall_Right;
    public TileBase[] TransitearthWall_Top;
    public TileBase[] TransitearthWall_Left;
    public TileBase[] TransitearthWall_Bottom;
    public TileBase[] TransitearthCorner_RightBottom;
    public TileBase[] TransitearthCorner_RightTop;
    public TileBase[] TransitearthCorner_LeftTop;
    public TileBase[] TransitearthCorner_LeftBottom;
    public TileBase[] TransitearthHall_RightBottom;
    public TileBase[] TransitearthHall_RightTop;
    public TileBase[] TransitearthHall_LeftTop;
    public TileBase[] TransitearthHall_LeftBottom;

    public bool Render = false;
    private void Awake()
    {
        SetConst();
        TileControl.SetRules();
        PushTilemaps();
        PushTileBases();
    }
    private void SetConst()
    {
        RiverLow = _RiverLow;
        RiverHight = _RiverHight;
        BiomLow = _BiomLow;
       // ColdLow = _ColdLow;
        WaterHight = _WaterHight;
        SandHight = _SandHight;
        WaterTilemap = _WaterTilemap;
        SandTilemap = _SandTilemap;
        EarthTilemap = _EarthTilemap;
        WaterTransitTilemap = _WaterTransitTilemap;
        SandTransitTilemap = _SandTransitTilemap;
        EarthTransitTilemap = _EarthTransitTilemap;
    }
    private void PushTilemaps()
    {
        TilePallet.Water.tilemap = _WaterTilemap;
        TilePallet.Sand.tilemap = _SandTilemap;
        TilePallet.Earth.tilemap = _EarthTilemap;
        TilePallet.TransitWater.tilemap = _WaterTransitTilemap;
        TilePallet.TransitSand.tilemap = _SandTransitTilemap;
        TilePallet.TransitEarth.tilemap = _EarthTransitTilemap;
    }

    private void PushTileBases()
    {
        TilePallet.Water.Filled = waterFill;

        TilePallet.Sand.Filled = sandFill;
        TilePallet.Sand.Wall_Right = sandWall_Right;
        TilePallet.Sand.Wall_Top = sandWall_Top;
        TilePallet.Sand.Wall_Left = sandWall_Left;
        TilePallet.Sand.Wall_Bottom = sandWall_Bottom;
        TilePallet.Sand.Corner_RightBottom = sandCorner_RightBottom;
        TilePallet.Sand.Corner_RightTop = sandCorner_RightTop;
        TilePallet.Sand.Corner_LeftTop = sandCorner_LeftTop;
        TilePallet.Sand.Corner_LeftBottom = sandCorner_LeftBottom;

        TilePallet.Earth.Filled = earthFill;
        TilePallet.Earth.Wall_Right = earthWall_Right;
        TilePallet.Earth.Wall_Top = earthWall_Top;
        TilePallet.Earth.Wall_Left = earthWall_Left;
        TilePallet.Earth.Wall_Bottom = earthWall_Bottom;
        TilePallet.Earth.Corner_RightBottom = earthCorner_RightBottom;
        TilePallet.Earth.Corner_RightTop = earthCorner_RightTop;
        TilePallet.Earth.Corner_LeftTop = earthCorner_LeftTop;
        TilePallet.Earth.Corner_LeftBottom = earthCorner_LeftBottom;

        TilePallet.TransitWater.Wall_Right = TransitwaterWall_Right;
        TilePallet.TransitWater.Wall_Top = TransitwaterWall_Top;
        TilePallet.TransitWater.Wall_Left = TransitwaterWall_Left;
        TilePallet.TransitWater.Wall_Bottom = TransitwaterWall_Bottom;
        TilePallet.TransitWater.Corner_RightBottom = TransitwaterCorner_RightBottom;
        TilePallet.TransitWater.Corner_RightTop = TransitwaterCorner_RightTop;
        TilePallet.TransitWater.Corner_LeftTop = TransitwaterCorner_LeftTop;
        TilePallet.TransitWater.Corner_LeftBottom = TransitwaterCorner_LeftBottom;

        TilePallet.TransitWater.Hall_RightBottom = TransitwaterCorner_RightBottom;
        TilePallet.TransitWater.Hall_RightTop = TransitwaterCorner_RightTop;
        TilePallet.TransitWater.Hall_LeftTop = TransitwaterCorner_LeftTop;
        TilePallet.TransitWater.Hall_LeftBottom = TransitwaterCorner_LeftBottom;
        
        TilePallet.TransitSand.Wall_Right = TransitsandWall_Right;
        TilePallet.TransitSand.Wall_Top = TransitsandWall_Top;
        TilePallet.TransitSand.Wall_Left = TransitsandWall_Left;
        TilePallet.TransitSand.Wall_Bottom = TransitsandWall_Bottom;
        TilePallet.TransitSand.Corner_RightBottom = TransitsandCorner_RightBottom;
        TilePallet.TransitSand.Corner_RightTop = TransitsandCorner_RightTop;
        TilePallet.TransitSand.Corner_LeftTop = TransitsandCorner_LeftTop;
        TilePallet.TransitSand.Corner_LeftBottom = TransitsandCorner_LeftBottom;
        TilePallet.TransitSand.Hall_RightBottom = TransitsandCorner_RightBottom;
        TilePallet.TransitSand.Hall_RightTop = TransitsandCorner_RightTop;
        TilePallet.TransitSand.Hall_LeftTop = TransitsandCorner_LeftTop;
        TilePallet.TransitSand.Hall_LeftBottom = TransitsandCorner_LeftBottom;

        TilePallet.TransitEarth.Wall_Right = TransitearthWall_Right;
        TilePallet.TransitEarth.Wall_Top = TransitearthWall_Top;
        TilePallet.TransitEarth.Wall_Left = TransitearthWall_Left;
        TilePallet.TransitEarth.Wall_Bottom = TransitearthWall_Bottom;
        TilePallet.TransitEarth.Corner_RightBottom = TransitearthCorner_RightBottom;
        TilePallet.TransitEarth.Corner_RightTop = TransitearthCorner_RightTop;
        TilePallet.TransitEarth.Corner_LeftTop = TransitearthCorner_LeftTop;
        TilePallet.TransitEarth.Corner_LeftBottom = TransitearthCorner_LeftBottom;
        TilePallet.TransitEarth.Hall_RightBottom = TransitearthCorner_RightBottom;
        TilePallet.TransitEarth.Hall_RightTop = TransitearthCorner_RightTop;
        TilePallet.TransitEarth.Hall_LeftTop = TransitearthCorner_LeftTop;
        TilePallet.TransitEarth.Hall_LeftBottom = TransitearthCorner_LeftBottom;
    }


    private static void SetNeighbors(int CoordMiddle, int width, TileType[] Grounds, BiomType[] Bioms, ref TileType[] neighbors, ref BiomType[] bioms)
    {
        for (byte y = 0; y < 3; y++)
            for (byte x = 0; x < 3; x++)
            {
                neighbors[y * 3 + x] = Grounds[CoordMiddle + width * (1 - y) + x - 1];
                bioms[y * 3 + x] = Bioms[CoordMiddle + width * (1 - y) + x - 1];
            }
    }
    public static void SetTypeMaps(PerlinMap GroundMap, PerlinMap BiomMap, ref TileType[] Grounds, ref BiomType[] Bioms)
    {
        for (int y = 0; y < MapManager.TileMapWidth + 2; y++)
            for (int x = 0; x < MapManager.TileMapWidth + 2; x++)
            {
                // Debug.Log("x -" + x + " PositionX -" + positionX);
                // Debug.Log("y - " + y + " posY"+ positionY);
                // Debug.Log("x -" + x + " PositionX -" + x / BiomMap.size);
                // Debug.Log("y - " + y + " posY "+ y / BiomMap.size);
               // Debug.Log("Coord TypeMap - "+ (int)(x + y * (MapManager.TileMapWidth + 2)) + "  coord in Map  - " + (int)(x / GroundMap.size + (y / GroundMap.size) * GroundMap.width));
               
                Grounds[x + y * (MapManager.TileMapWidth + 2)] = GetTileType(GroundMap.floatArray[x / GroundMap.size + (y / GroundMap.size) * GroundMap.width]);
                Bioms[x + y * (MapManager.TileMapWidth + 2)] = GetBiomType(BiomMap.floatArray[x / BiomMap.size + (y / BiomMap.size) * BiomMap.width]);
            }
    }


    public static void PrintTileMap(GroundData[] TileMap, Vector2Int offset)
    {
        int OffsetX = MapManager.TileMapWidth * offset.x;
        int OffsetY = MapManager.TileMapWidth * offset.y;
        for (int y = 0; y < MapManager.TileMapWidth; y++)
         for (int x = 0; x < MapManager.TileMapWidth; x++)
          if (TileMap[x + y * MapManager.TileMapWidth] != null)
          {
              TileMap[x + y * MapManager.TileMapWidth].tilemap.SetTile(new Vector3Int(x + OffsetX, y + OffsetY), TileMap[x + y * MapManager.TileMapWidth].tile);
              if (TileMap[x + y * MapManager.TileMapWidth].TransitionTilemap != null)
                TileMap[x + y * MapManager.TileMapWidth].TransitionTilemap.SetTile(new Vector3Int(x + OffsetX, y + OffsetY), TileMap[x + y * MapManager.TileMapWidth].TransitionTile);
          }
    }

    public static void ClearPart(Vector2Int offset)
    {
        int OffsetX = MapManager.TileMapWidth * offset.x;
        int OffsetY = MapManager.TileMapWidth * offset.y;
        for (int y = 0; y < MapManager.TileMapWidth; y++)
            for (int x = 0; x < MapManager.TileMapWidth; x++)
            {
                WaterTilemap.SetTile(new Vector3Int(x + OffsetX, y + OffsetY), null);
                SandTilemap.SetTile(new Vector3Int(x + OffsetX, y + OffsetY), null);
                EarthTilemap.SetTile(new Vector3Int(x + OffsetX, y + OffsetY), null);
                WaterTransitTilemap.SetTile(new Vector3Int(x + OffsetX, y + OffsetY), null);
                SandTransitTilemap.SetTile(new Vector3Int(x + OffsetX, y + OffsetY), null);
                EarthTransitTilemap.SetTile(new Vector3Int(x + OffsetX, y + OffsetY), null);
            }
    }
    public static GroundData[] GetTileMap(TileType[] MainMap, BiomType[] BiomMap, int WidthTypeMaps)
    {
        GroundData[] TileMap = new GroundData[(WidthTypeMaps - 2) * (WidthTypeMaps - 2)];
        TileType[] neighbors = new TileType[9];
        BiomType[] bioms = new BiomType[9];
        for (int y = 1; y < WidthTypeMaps - 1; y++)
        {
            for (int x = 1; x < WidthTypeMaps - 1; x++)
            {
                SetNeighbors(x + y * WidthTypeMaps, WidthTypeMaps, MainMap, BiomMap, ref neighbors, ref bioms);
                TileMap[x - 1 + (y -1) * (WidthTypeMaps - 2)] = TileControl.GetCorrectTiles(neighbors, bioms);
            }
        }
        return TileMap;
    }

    public static BiomType GetBiomType(float color)
    {
        if (color <= (int)BiomType.atlantic)
            return BiomType.usual;
        else if (color <= (int)BiomType.blood)
            return BiomType.atlantic;
        else
            return BiomType.blood;
    }
    public static TileType GetTileType(float color)
    {
        if (color <= WaterHight)
            return TileType.water;
        else if (color <= SandHight)
            return TileType.sand;
        else
            return TileType.earth;
    }
    public static bool IsItRiver(float color)
    {
        return color <= RiverHight && color >= RiverLow;
    }
    public static bool IsItBiom(float color)
    {
        return color >= BiomLow;
    }
    public static TileType GetTileType(Vector2 WorldCoord, PerlinMap map)
    {
        int ArrayCoord = ((int)WorldCoord.x + map.width * (int)WorldCoord.y) / map.size;
        return GetTileType(map.floatArray[ArrayCoord]);
    }
}

    //private static void SetNeighbors(int CoordMiddle, Map map, Map biomMap, ref TileType[] neighbors, ref BiomType[] bioms)
    //{
    //    for (byte y = 0; y < 3; y++)
    //        for (byte x = 0; x < 3; x++)
    //        {
    //            neighbors[y * 3 + x] = GetTileType(map.floatArray[CoordMiddle + map.width * (1 - y) + x - 1]);
    //            bioms[y * 3 + x] = GetBiomType(biomMap.floatArray[CoordMiddle + map.width * (1 - y) + x - 1]);
    //        }
    //}
    //public static void SetTiles(Vector3Int coord, GroundData[] data)
    //{
    //    byte i = 0;
    //    foreach (GroundData item in data)
    //        item.tilemap.SetTile(coord, data[i].tile);
    //}
    //public static void GenerateTileMapPast(Map MainMap, Map BiomMap)
    //{
    //    TileType[] TypeMap = new TileType[MainMap.floatArray.Length * MainMap.size * MainMap.size];
    //    BiomType[] BiomTypeMap = new BiomType[TypeMap.Length];
    //    TileType[] neighbors = new TileType[9];
    //    BiomType[] bioms = new BiomType[9];
    //    SetTypeMaps(MainMap, BiomMap, ref TypeMap, ref BiomTypeMap);
    //    int TileMapWidth = MainMap.width * MainMap.size;
    //    for (int y = 1; y < TileMapWidth - 1; y++)
    //    {
    //        for (int x = 1; x < TileMapWidth - 1; x++)
    //        {
    //            //  SetNeighbors(x + y * MainMap.width, MainMap, BiomMap, ref neighbors, ref bioms);
    //            SetNeighbors(x + y * TileMapWidth, TileMapWidth, TypeMap, BiomTypeMap, ref neighbors, ref bioms);
    //            //  SetTiles(new Vector3Int(x, y), TileControlTree.GetCorrectTiles(neighbors, bioms));
    //            GroundData data = TileControl.GetCorrectTiles(neighbors, bioms);
    //            data.tilemap.SetTile(new Vector3Int(x, y), data.tile);
    //        }
    //    }
    //}
    //public static void GenerateTileMap(Map MainMap, Map BiomMap)
    //{
    //    TileType[] neighbors = new TileType[9];
    //    BiomType[] bioms = new BiomType[9];
    //    for (int y = 1; y < MapManager.width - 1; y++)
    //    {
    //        for (int x = 1; x < MapManager.width - 1; x++)
    //        {
    //            //  SetNeighbors(x + y * MainMap.width, MainMap, BiomMap, ref neighbors, ref bioms);
    //            SetNeighbors(x + y * MapManager.width, MapManager.width, MapManager.CurrentUnit.TypeMap, MapManager.CurrentUnit.BiomTypeMap, ref neighbors, ref bioms);
    //            //  SetTiles(new Vector3Int(x, y), TileControlTree.GetCorrectTiles(neighbors, bioms));
    //            GroundData data = TileControl.GetCorrectTiles(neighbors, bioms);
    //            data.tilemap.SetTile(new Vector3Int(x, y), data.tile);
    //        }
    //    }
    //}