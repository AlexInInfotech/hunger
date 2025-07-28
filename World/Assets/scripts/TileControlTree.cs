
//public static class TileControlTree
//{
//    static RuleGraph rules = new RuleGraph();
//    static byte[] order = { 5, 1, 3, 7, 8, 2, 0, 6 };

//    class Rule
//    {
//        public bool[] path;
//        public TileForm tileform;

//        public Rule(bool[] _path, TileForm _tileform)
//        {
//            path = _path;
//            tileform = _tileform;
//        }
//    }

//    private static void AddRule(Rule rule)
//    {
//        RuleGraph CurrentGraph = rules;
//        for (byte i = 0; i < rule.path.Length; i++)
//        {
//            if (rule.path[i])
//            {
//                if (CurrentGraph.one == null)
//                    CurrentGraph.one = new RuleGraph();
//                CurrentGraph = CurrentGraph.one;
//            }
//            else
//            {
//                if (CurrentGraph.zero == null)
//                    CurrentGraph.zero = new RuleGraph();
//                CurrentGraph = CurrentGraph.zero;
//            }
//        }
//        CurrentGraph.rule = rule.tileform;
//    }
//    public static void SetRules() //  вызывается при старте один раз
//    {
//        Rule[] rules = new Rule[13];
//        bool[] Fill_Path = { true, true, true, true, true, true, true, true };
//        bool[] CornerLeftBottom_Path = { false, false };
//        bool[] CornerLeftTop_Path = { false, true, true, false };
//        bool[] CornerRightBottom_Path = { true, false, false};
//        bool[] CornerRightTop_Path = { true, true, false, false };
//        bool[] WallLeft_Path = { false, true, true, true };
//        bool[] WallRight_Path = { true, true, false,true };
//        bool[] WallTop_Path = {  true, true, true, false };
//        bool[] WallBottom_Path = { true, false, true };
//        bool[] RitLeftTop_Path = { true, true, true, true, false };
//        bool[] RitLeftBottom_Path = { true, true, true, true, true, false };
//        bool[] RitRightBottom_Path = { true, true, true, true, true, true, false };
//        bool[] RitRightTop_Path = { true, true, true, true, true, true, true, false };
//        rules[0] = new Rule(Fill_Path, TileForm.Fill);
//        rules[1] = new Rule(CornerLeftBottom_Path, TileForm.Corner_LeftBottom);
//        rules[2] = new Rule(CornerLeftTop_Path, TileForm.Corner_LeftTop);
//        rules[3] = new Rule(CornerRightBottom_Path, TileForm.Corner_RightBottom);
//        rules[4] = new Rule(CornerRightTop_Path, TileForm.Corner_RightTop);
//        rules[5] = new Rule(WallLeft_Path, TileForm.Wall_Left);
//        rules[6] = new Rule(WallRight_Path, TileForm.Wall_Right);
//        rules[7] = new Rule(WallTop_Path, TileForm.Wall_Top);
//        rules[8] = new Rule(WallBottom_Path, TileForm.Wall_Bottom);
//     /*   rules[9] = new Rule(RitLeftTop_Path, TileForm.Rit_LeftTop);
//        rules[10] = new Rule(RitLeftBottom_Path, TileForm.Rit_LeftBottom);
//        rules[11] = new Rule(RitRightBottom_Path, TileForm.Rit_RightBottom);
//        rules[12] = new Rule(RitRightTop_Path, TileForm.Rit_RightTop);*/
//        for (byte i = 0; i < rules.Length; i++)
//            AddRule(rules[i]);

//    }
//    public static GroundData[] GetCorrectTiles(TileType[] neighbors, BiomType[] bioms, int index = 0, GroundData[] OutData = null)
//    {
//        if (OutData == null)
//            OutData = new GroundData[3];
//        if (neighbors[4] == TileType.water)
//        {
//            OutData[index] = new GroundData(TilePallet.Waterr[0], TilePallet.WaterTilemap);
//            return OutData;
//        }
//        TileForm TileForm = GetRule(neighbors);
//        TileForm BiomForm = new TileForm();
//        OutData[index] = new GroundData();
//        GroundBase ground = new GroundBase();
//        if (neighbors[4] == TileType.sand)
//        {
//            ground = TilePallet.Sand;
//            neighbors = new TileType[9];
//        }
//        if (neighbors[4] == TileType.earth)
//        {
//            ground = TilePallet.Earth;
//            neighbors[4] = TileType.sand;
//        }
//        if (TileForm != TileForm.Fill)
//            GetCorrectTiles(neighbors, bioms, index + 1, OutData);
//        else
//            BiomForm = GetRule(bioms);
//        OutData[index].tile = ground.GetTile(TileForm, bioms[4], BiomForm);
//        OutData[index].tilemap = ground.tilemap;
//        return OutData;

//    }
//    private static TileForm GetRule(TileType[] neighbors)
//    {
//        byte i = 0;
//        RuleGraph Currentgraph = rules;
//        TileForm TileForm = new TileForm();
//        while (Currentgraph != null && i < 8)
//        {
//            if (neighbors[order[i]] >= neighbors[4])
//                Currentgraph = Currentgraph.one;
//            else
//                Currentgraph = Currentgraph.zero;
//            if (Currentgraph != null)
//                TileForm = Currentgraph.rule;
//            i++;
//        }
//        return TileForm;
//    }
//    private static TileForm GetRule(BiomType[] neighbors)
//    {
//        byte i = 0;
//        RuleGraph Currentgraph = rules;
//        TileForm TileForm = new TileForm();
//        while (Currentgraph != null && i < 8)
//        {
//            if (neighbors[order[i]] >= neighbors[4])
//                Currentgraph = Currentgraph.one;
//            else
//                Currentgraph = Currentgraph.zero;
//            if (Currentgraph != null)
//                TileForm = Currentgraph.rule;
//            i++;
//        }
//        return TileForm;
//    }
//}

