using UnityEngine;
using UnityEngine.Tilemaps;


public class TileManager : MonoBehaviour
{
    public Tilemap _WaterTilemap;
    public Tilemap _SandTilemap;
    public Tilemap _EarthTilemap;
    public Texture2DArray WaterTexture;
    public Texture2DArray SandTexture;
    public Texture2DArray EarthTexture;
    public Material WaterMaterial;
    public Material SandMaterial;
    public Material EarthMaterial;

    static float RiverLow;
    static float RiverHight;
    static float BiomLow;
   // static float ColdLow;
    static float WaterHight;
    static float SandHight;
    static Tilemap WaterTilemap;
    static Tilemap SandTilemap;
    static Tilemap EarthTilemap;

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

    //public TileBase[] TransitwaterWall_Right;
    //public TileBase[] TransitwaterWall_Top;
    //public TileBase[] TransitwaterWall_Left;
    //public TileBase[] TransitwaterWall_Bottom;
    //public TileBase[] TransitwaterCorner_RightBottom;
    //public TileBase[] TransitwaterCorner_RightTop;
    //public TileBase[] TransitwaterCorner_LeftTop;
    //public TileBase[] TransitwaterCorner_LeftBottom;
    //public TileBase[] TransitwaterHall_RightBottom;
    //public TileBase[] TransitwaterHall_RightTop;
    //public TileBase[] TransitwaterHall_LeftTop;
    //public TileBase[] TransitwaterHall_LeftBottom;


    //public TileBase[] TransitsandWall_Right;
    //public TileBase[] TransitsandWall_Top;
    //public TileBase[] TransitsandWall_Left;
    //public TileBase[] TransitsandWall_Bottom;
    //public TileBase[] TransitsandCorner_RightBottom;
    //public TileBase[] TransitsandCorner_RightTop;
    //public TileBase[] TransitsandCorner_LeftTop;
    //public TileBase[] TransitsandCorner_LeftBottom;
    //public TileBase[] TransitsandHall_RightBottom;
    //public TileBase[] TransitsandHall_RightTop;
    //public TileBase[] TransitsandHall_LeftTop;
    //public TileBase[] TransitsandHall_LeftBottom;
    
    //public TileBase[] TransitearthFill;
    //public TileBase[] TransitearthWall_Right;
    //public TileBase[] TransitearthWall_Top;
    //public TileBase[] TransitearthWall_Left;
    //public TileBase[] TransitearthWall_Bottom;
    //public TileBase[] TransitearthCorner_RightBottom;
    //public TileBase[] TransitearthCorner_RightTop;
    //public TileBase[] TransitearthCorner_LeftTop;
    //public TileBase[] TransitearthCorner_LeftBottom;
    //public TileBase[] TransitearthHall_RightBottom;
    //public TileBase[] TransitearthHall_RightTop;
    //public TileBase[] TransitearthHall_LeftTop;
    //public TileBase[] TransitearthHall_LeftBottom;

    public bool Render = false;
    private void Awake()
    {
        SetConst();
        TileControl.SetRules();
        PushTileBases();
        WaterMaterial.SetFloat("_TilesCount", WaterTexture.depth);
        SandMaterial.SetFloat("_TilesCount", SandTexture.depth);
        EarthMaterial.SetFloat("_TilesCount", EarthTexture.depth);
        BiomType[] bioms =
       {
            BiomType.usual, BiomType.usual, BiomType.usual,
            BiomType.usual, BiomType.usual, BiomType.usual,
            BiomType.atlantic, BiomType.atlantic, BiomType.atlantic
        };
        GroundData data = TileControl.GetCorrectTiles(new TileType[9], bioms);
        SandTilemap.SetTile(new Vector3Int(0, 0), data.Tile);
        SandTilemap.SetColor(new Vector3Int(0, 0), data.States3);
        Debug.Log(data.States3 );


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
    }
    

    private void PushTileBases()
    {
        TilePallet.CountBioms = 2;
        TilePallet.Water.tilemap = _WaterTilemap;
        TilePallet.Water.CountStates = WaterTexture.depth;
        TilePallet.Water.Filled = waterFill;

        TilePallet.Sand.tilemap = _SandTilemap;
        TilePallet.Sand.CountStates = SandTexture.depth;
        TilePallet.Sand.Filled = sandFill;
        TilePallet.Sand.Wall_Right = sandWall_Right;
        TilePallet.Sand.Wall_Top = sandWall_Top;
        TilePallet.Sand.Wall_Left = sandWall_Left;
        TilePallet.Sand.Wall_Bottom = sandWall_Bottom;
        TilePallet.Sand.Corner_RightBottom = sandCorner_RightBottom;
        TilePallet.Sand.Corner_RightTop = sandCorner_RightTop;
        TilePallet.Sand.Corner_LeftTop = sandCorner_LeftTop;
        TilePallet.Sand.Corner_LeftBottom = sandCorner_LeftBottom;

        TilePallet.Earth.tilemap = _EarthTilemap;
        TilePallet.Earth.CountStates = EarthTexture.depth;
        TilePallet.Earth.Filled = earthFill;
        TilePallet.Earth.Wall_Right = earthWall_Right;
        TilePallet.Earth.Wall_Top = earthWall_Top;
        TilePallet.Earth.Wall_Left = earthWall_Left;
        TilePallet.Earth.Wall_Bottom = earthWall_Bottom;
        TilePallet.Earth.Corner_RightBottom = earthCorner_RightBottom;
        TilePallet.Earth.Corner_RightTop = earthCorner_RightTop;
        TilePallet.Earth.Corner_LeftTop = earthCorner_LeftTop;
        TilePallet.Earth.Corner_LeftBottom = earthCorner_LeftBottom;

        //tilepallet.transitwater.wall_right = transitwaterwall_right;
        //tilepallet.transitwater.wall_top = transitwaterwall_top;
        //tilepallet.transitwater.wall_left = transitwaterwall_left;
        //tilepallet.transitwater.wall_bottom = transitwaterwall_bottom;
        //tilepallet.transitwater.corner_rightbottom = transitwatercorner_rightbottom;
        //tilepallet.transitwater.corner_righttop = transitwatercorner_righttop;
        //tilepallet.transitwater.corner_lefttop = transitwatercorner_lefttop;
        //tilepallet.transitwater.corner_leftbottom = transitwatercorner_leftbottom;

        //tilepallet.transitwater.hall_rightbottom = transitwatercorner_rightbottom;
        //tilepallet.transitwater.hall_righttop = transitwatercorner_righttop;
        //tilepallet.transitwater.hall_lefttop = transitwatercorner_lefttop;
        //tilepallet.transitwater.hall_leftbottom = transitwatercorner_leftbottom;

        //tilepallet.transitsand.wall_right = transitsandwall_right;
        //tilepallet.transitsand.wall_top = transitsandwall_top;
        //tilepallet.transitsand.wall_left = transitsandwall_left;
        //tilepallet.transitsand.wall_bottom = transitsandwall_bottom;
        //tilepallet.transitsand.corner_rightbottom = transitsandcorner_rightbottom;
        //tilepallet.transitsand.corner_righttop = transitsandcorner_righttop;
        //tilepallet.transitsand.corner_lefttop = transitsandcorner_lefttop;
        //tilepallet.transitsand.corner_leftbottom = transitsandcorner_leftbottom;
        //tilepallet.transitsand.hall_rightbottom = transitsandcorner_rightbottom;
        //tilepallet.transitsand.hall_righttop = transitsandcorner_righttop;
        //tilepallet.transitsand.hall_lefttop = transitsandcorner_lefttop;
        //tilepallet.transitsand.hall_leftbottom = transitsandcorner_leftbottom;

        //tilepallet.transitearth.wall_right = transitearthwall_right;
        //tilepallet.transitearth.wall_top = transitearthwall_top;
        //tilepallet.transitearth.wall_left = transitearthwall_left;
        //tilepallet.transitearth.wall_bottom = transitearthwall_bottom;
        //tilepallet.transitearth.corner_rightbottom = transitearthcorner_rightbottom;
        //tilepallet.transitearth.corner_righttop = transitearthcorner_righttop;
        //tilepallet.transitearth.corner_lefttop = transitearthcorner_lefttop;
        //tilepallet.transitearth.corner_leftbottom = transitearthcorner_leftbottom;
        //tilepallet.transitearth.hall_rightbottom = transitearthcorner_rightbottom;
        //tilepallet.transitearth.hall_righttop = transitearthcorner_righttop;
        //tilepallet.transitearth.hall_lefttop = transitearthcorner_lefttop;
        //tilepallet.transitearth.hall_leftbottom = transitearthcorner_leftbottom;
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
    public static void ConvertPerlinToTypes(PerlinMap GroundMap, PerlinMap BiomMap, ref TileType[] Grounds, ref BiomType[] Bioms)
    {
        for (int y = 0; y < MapManager.TileMapWidth + 2; y++)
            for (int x = 0; x < MapManager.TileMapWidth + 2; x++)
            {
                Grounds[x + y * (MapManager.TileMapWidth + 2)] = GetTileType(GroundMap.floatArray[x / GroundMap.size + (y / GroundMap.size) * GroundMap.width]);
                Bioms[x + y * (MapManager.TileMapWidth + 2)] = GetBiomType(BiomMap.floatArray[x / BiomMap.size + (y / BiomMap.size) * BiomMap.width]);
            }
    }
    public static void PrintWorldUnit(WorldUnit unit)
    {
        Vector3Int[] WaterPos = new Vector3Int[unit.TilesData.Length];
        Vector3Int[] SandPos = new Vector3Int[unit.TilesData.Length];
        Vector3Int[] EarthPos = new Vector3Int[unit.TilesData.Length];
        TileBase[] WaterBases = new TileBase[unit.TilesData.Length];
        TileBase[] SandBases = new TileBase[unit.TilesData.Length];
        TileBase[] EarthBases = new TileBase[unit.TilesData.Length];
        int WaterI = 0;
        int SandI = 0;
        int EarthI = 0;
        int OffsetX = MapManager.TileMapWidth * unit.Coord.x;
        int OffsetY = MapManager.TileMapWidth * unit.Coord.y;
        for (int y = 0; y < MapManager.TileMapWidth; y++)
            for (int x = 0; x < MapManager.TileMapWidth; x++)
                switch(unit.TilesData[x + y * MapManager.TileMapWidth].TileType)
                {
                    case TileType.water:
                        WaterPos[WaterI].x = OffsetX + x;
                        WaterPos[WaterI].y = OffsetY + y;
                        WaterBases[WaterI] = unit.TilesData[x + y * MapManager.TileMapWidth].Tile;
                        WaterI++;
                        break;
                    case TileType.sand:
                        SandPos[SandI].x = OffsetX + x;
                        SandPos[SandI].y = OffsetY + y;
                        SandBases[SandI] = unit.TilesData[x + y * MapManager.TileMapWidth].Tile;
                        SandI++;
                        break;
                    case TileType.earth:
                        EarthPos[EarthI].x = OffsetX + x;
                        EarthPos[EarthI].y = OffsetY + y;
                        EarthBases[EarthI] = unit.TilesData[x + y * MapManager.TileMapWidth].Tile;
                        EarthI++;
                        break;
                }
        WaterTilemap.SetTiles(WaterPos, WaterBases);
        SandTilemap.SetTiles(SandPos, SandBases);
        EarthTilemap.SetTiles(EarthPos, EarthBases);
        for (int y = 0; y < MapManager.TileMapWidth; y++)
            for (int x = 0; x < MapManager.TileMapWidth; x++)
            {
                Debug.Log(unit.TilesData[x + y * MapManager.TileMapWidth].States3);
                unit.TilesData[x + y * MapManager.TileMapWidth].Tilemap.SetColor(new Vector3Int(x + OffsetX, y + OffsetY), unit.TilesData[x + y * MapManager.TileMapWidth].States3);
            }
        unit.IsActive = true; 

    }

    //public static void PrintTileMap(GroundData[] Data, Vector2Int offset)
    //{
    //    int OffsetX = MapManager.TileMapWidth * offset.x;
    //    int OffsetY = MapManager.TileMapWidth * offset.y;
    //    for (int y = 0; y < MapManager.TileMapWidth; y++)
    //        for (int x = 0; x < MapManager.TileMapWidth; x++)
    //            if (Data[x + y * MapManager.TileMapWidth] != null)
    //            {
    //                Data[x + y * MapManager.TileMapWidth].Tilemap.SetTile(new Vector3Int(x + OffsetX, y + OffsetY), Data[x + y * MapManager.TileMapWidth].TransitTile);
    //                Data[x + y * MapManager.TileMapWidth].Tilemap.SetColor(new Vector3Int(x + OffsetX, y + OffsetY), Data[x + y * MapManager.TileMapWidth].Color);
    //            }
    //            else
    //                Debug.Log("Null Ground Data");
    //}

    public static void ClearPart(Vector2Int offset)
    {
        Vector3Int[] Pos = new Vector3Int[MapManager.TileMapWidth* MapManager.TileMapWidth];
        TileBase[] Bases = new TileBase[Pos.Length];
        int OffsetX = MapManager.TileMapWidth * offset.x;
        int OffsetY = MapManager.TileMapWidth * offset.y;
        for (int y = 0; y < MapManager.TileMapWidth; y++)
            for (int x = 0; x < MapManager.TileMapWidth; x++)
            {
                Pos[x + y * MapManager.TileMapWidth].x = x + OffsetX;
                Pos[x + y * MapManager.TileMapWidth].y = y + OffsetY;
            }
        WaterTilemap.SetTiles(Pos, Bases);
        SandTilemap.SetTiles(Pos, Bases);
        EarthTilemap.SetTiles(Pos, Bases);
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
           // return BiomType.blood
            return BiomType.atlantic;
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
